using Tesodev.Case.Order.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Tesodev.Case.Order.Infrastructure.Repositories;

public class OrderRepository : Domain.AggregatesModel.OrderAggregate.IOrderRepository
{
    private readonly OrderContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public OrderRepository(OrderContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="order"><inheritdoc/></param>
    /// <returns><inheritdoc/></returns>
    public async Task<Domain.AggregatesModel.OrderAggregate.Order> AddAsync(Domain.AggregatesModel.OrderAggregate.Order order)
    {
        return (await _context.Orders.AddAsync(order)).Entity;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public async void Delete(Domain.AggregatesModel.OrderAggregate.Order order)
    {
        _context.Orders.Remove(order);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public async Task<List<Domain.AggregatesModel.OrderAggregate.Order>> GetAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public async Task<Domain.AggregatesModel.OrderAggregate.Order> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="order"><inheritdoc/></param>
    /// <returns><inheritdoc/></returns>
    public Domain.AggregatesModel.OrderAggregate.Order Update(Domain.AggregatesModel.OrderAggregate.Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        return order;
    }
}