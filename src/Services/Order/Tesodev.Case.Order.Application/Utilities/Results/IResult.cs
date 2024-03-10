namespace Tesodev.Case.Order.Application.Utilities.Results;

public interface IResult<out T>
{
    bool Success { get; }
    T Message { get; }
}