using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SwiftMessageApi.Parsers
{
    public class SwiftMessageParser
    {
    public static SwiftMessage Parse(string swiftMessage)
    {
        var parsedMessage = new SwiftMessage();

        var regex = new Regex(@":(\w{2})([^:]+)", RegexOptions.Multiline);
        var matches = regex.Matches(swiftMessage);

        foreach (Match match in matches)
        {
            var fieldCode = match.Groups[1].Value;
            var fieldValue = match.Groups[2].Value.Trim();

            ProcessField(parsedMessage, fieldCode, fieldValue);
        }

        
        parsedMessage.MessageType = "MT799";
        parsedMessage.Timestamp = DateTime.UtcNow;

        return parsedMessage;
    }

    private static void ProcessField(SwiftMessage parsedMessage, string fieldCode, string fieldValue)
    {
        switch (fieldCode)
        {
            case "20":
                parsedMessage.Sender = fieldValue;
                break;
            case "21":
                parsedMessage.Receiver = fieldValue;
                break;
            case "22A":
                parsedMessage.TransactionReference = fieldValue;
                break;
            case "32A":
                parsedMessage.ValueDate = fieldValue;
                break;
            case "33B":
                parsedMessage.Amount = ParseDecimalValue(fieldValue);
                break;
            case "33C":
                parsedMessage.Currency = fieldValue;
                break;
            
            default:
                break;
        }
    }
     private static decimal ParseDecimalValue(string fieldValue)
    {
        //  Този метод, ParseDecimalValue, използва decimal.TryParse за парсиране на десетичните числа, като експлицитно установява System.Globalization.CultureInfo.InvariantCulture за разделител на десетичния знак.
        if (decimal.TryParse(fieldValue, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

        return 0;
    }
}
}