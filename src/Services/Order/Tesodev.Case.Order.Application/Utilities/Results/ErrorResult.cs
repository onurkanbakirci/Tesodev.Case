namespace Tesodev.Case.Order.Application.Utilities.Results;

public class ErrorResult : Result
{
    public ErrorResult(string internalMessage) : base(false, internalMessage)
    {
    }

    public ErrorResult() : base(false)
    {
    }
}