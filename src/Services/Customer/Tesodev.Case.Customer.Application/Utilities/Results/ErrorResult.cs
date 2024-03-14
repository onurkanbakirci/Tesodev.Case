namespace Tesodev.Case.Customer.Application.Utilities.Results;

public class ErrorResult : Result
{
   public ErrorResult(string internalMessage) : base(false, internalMessage)
    {
    }

    public ErrorResult() : base(false)
    {
    }
}