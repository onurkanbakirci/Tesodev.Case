using System.Text.Json.Serialization;

namespace Tesodev.Case.Order.Application.Utilities.Results;

public class Result : IResult
{
    [JsonConstructor]
    public Result(bool success, string internalMessage) : this(success)
    {
        InternalMessage = internalMessage;
    }

    public Result(bool success)
    {
        Success = success;
    }

    public bool Success { get; }
    public string Message { get; set; }
    public string InternalMessage { get; set; }
}