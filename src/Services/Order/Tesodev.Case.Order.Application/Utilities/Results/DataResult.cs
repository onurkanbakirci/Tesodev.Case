using Newtonsoft.Json;

namespace Tesodev.Case.Order.Application.Utilities.Results;
public class DataResult<T> : Result, IDataResult<T>
{
    [JsonConstructor]
    public DataResult(T data, bool success, string internalMessage) : base(success, internalMessage)
    {
        Data = data;
    }

    public DataResult(T data, bool success) : base(success)
    {
        Data = data;
    }

    public T Data { get; }
}