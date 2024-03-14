namespace Tesodev.Case.Customer.Application.Utilities.Results;
public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data, string internalMessage) : base(data, false, internalMessage)
    {

    }

    public ErrorDataResult(T data) : base(data, false)
    {
    }

    public ErrorDataResult(string internalMessage) : base(default, false, internalMessage)
    {

    }

    public ErrorDataResult() : base(default, false)
    {

    }
}