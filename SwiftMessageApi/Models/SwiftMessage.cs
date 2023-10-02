public class SwiftMessage
{
    public int Id { get; set; }

    // Общи полета
    public string MessageType { get; set; } = string.Empty;
    public string Sender { get; set; } = string.Empty;
    public string Receiver { get; set; } = string.Empty;

    // Полета, специфични за Swift MT799
    public string TransactionReference { get; set; } = string.Empty;
    public string ValueDate { get; set; } = string.Empty;
    public decimal Amount { get; set; } = 0;
    public string Currency { get; set; } = string.Empty;

    // Полета за MT799
    public string SenderReference { get; set; } = string.Empty;
    public string ReceiverReference { get; set; } = string.Empty;
    public string InstructionsForBeneficiary { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }

    public bool IsValid(out string errorMessage)
    {
        if (string.IsNullOrEmpty(MessageType))
        {
            errorMessage = "MessageType is required.";
            return false;
        }

        if (string.IsNullOrEmpty(Sender))
        {
            errorMessage = "Sender is required.";
            return false;
        }

        // ... other validations ...

        if (Timestamp == default(DateTime))
        {
            errorMessage = "Timestamp is required.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}