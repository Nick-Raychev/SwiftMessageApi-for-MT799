using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Swagger configuration
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SwiftMessageApi",
                Version = "v1",
                Description = "A description of SwiftMessageApi."
            });
        });
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("SwiftMessageApiConnection")));
    }

   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        // Swagger UI configuration
        app.UseSwagger();
        app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwiftMessageApi V1");
                c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root (http://localhost:<port>/)
                c.DocExpansion(DocExpansion.None);
            });
    }

    app.UseHttpsRedirection();

    app.UseRouting(); // Ensure this is called before UseAuthorization

    app.UseAuthorization(); // This should come after UseRouting

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

}