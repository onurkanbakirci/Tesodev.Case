namespace Tesodev.Case.Order.Application.Utilities.Results;

public class ErrorResult<T> : Result<T>
{
    public ErrorResult(T message)
        : base(false, message)
    {
    }

    public ErrorResult()
        : base(false)
    {
    }
}