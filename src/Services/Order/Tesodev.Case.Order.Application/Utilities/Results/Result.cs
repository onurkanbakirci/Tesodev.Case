using System.Text.Json.Serialization;

namespace Tesodev.Case.Order.Application.Utilities.Results;

public class Result<T> : IResult<T>
{
    public Result(bool success, T message)
        : this(success)
    {
        Message = message;
    }

    public Result(bool success)
    {
        Success = success;
    }

    [JsonPropertyName("result")]
    public bool Success { get; }
    public T Message { get; }
}