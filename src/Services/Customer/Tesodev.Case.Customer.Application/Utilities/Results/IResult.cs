namespace Tesodev.Case.Customer.Application.Utilities.Results;

public interface IResult
{
    bool Success { get; }
    string Message { get; set; }
    string InternalMessage { get; set; }
}