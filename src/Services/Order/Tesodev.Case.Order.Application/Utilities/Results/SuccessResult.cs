namespace Tesodev.Case.Order.Application.Utilities.Results;

public class SuccessResult : Result
{
    public SuccessResult(string internalMessage) : base(true, internalMessage)
    {
    }

    public SuccessResult() : base(true)
    {
    }
}