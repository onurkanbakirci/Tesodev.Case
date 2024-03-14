using Newtonsoft.Json;

namespace Tesodev.Case.Order.Application.Utilities.Results;
public class SuccessDataResult<T> : DataResult<T>
{
    [JsonConstructor]
    public SuccessDataResult(T data, string internalMessage) : base(data, true, internalMessage)
    {
    }

    public SuccessDataResult(T data) : base(data, true)
    {
    }

    public SuccessDataResult(string internalMessage) : base(default, true, internalMessage)
    {
    }

    public SuccessDataResult() : base(default, true)
    {
    }
}