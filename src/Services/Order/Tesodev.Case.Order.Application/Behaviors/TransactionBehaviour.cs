using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Order.Infrastructure;

namespace Tesodev.Case.Order.Application.Behaviors;
public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly OrderContext _dbContext;

    public TransactionBehaviour(OrderContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(nameof(OrderContext));
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var response = default(TResponse);
        try
        {
            if (_dbContext.HasActiveTransaction)
                return await next();

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                Guid transactionId;

                using (var transaction = await _dbContext.BeginTransactionAsync())
                {
                    response = await next();

                    await _dbContext.CommitTransactionAsync(transaction);

                    transactionId = transaction.TransactionId;
                }
            });
            return response;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}