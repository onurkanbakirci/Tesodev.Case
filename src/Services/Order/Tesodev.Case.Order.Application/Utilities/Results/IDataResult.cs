namespace Tesodev.Case.Order.Application.Utilities.Results;
public interface IDataResult<out T> : IResult
{
    T Data { get; }
}