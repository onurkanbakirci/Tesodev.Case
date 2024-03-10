namespace Tesodev.Case.Customer.Application.Utilities.Results;

public interface IResult<out T>
{
    bool Success { get; }
    T Message { get; }
}