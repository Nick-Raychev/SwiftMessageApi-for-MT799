using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwiftMessageApi.Parsers;  // Уверете се, че този импорт е правилен

namespace SwiftMessageApi.Controllers
{
    /// <summary>
/// Controller for handling Swift messages.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SwiftMessageController : ControllerBase
{
    private readonly ILogger<SwiftMessageController> _logger;
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwiftMessageController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="dbContext">The database context.</param>
    public SwiftMessageController(ILogger<SwiftMessageController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Post a Swift MT799 message.
    /// </summary>
    /// <param name="swiftMessage">The Swift MT799 message.</param>
    /// <returns>Returns the result of the operation.</returns>
    [HttpPost]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(400, Type = typeof(string))]
    [ProducesResponseType(500, Type = typeof(string))]
    public IActionResult Post([FromBody] string swiftMessage)
    {
        try
        {
            // Parse the message
            var parsedMessage = SwiftMessageParser.Parse(swiftMessage);

            _logger.LogInformation($"Received Swift MT799 Message: {swiftMessage}");

            // Save to the database
            _dbContext.SwiftMessages.Add(parsedMessage);
            _dbContext.SaveChanges();

            return Ok("Swift MT799 Message successfully processed and saved.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing Swift MT799 Message: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    
}
}