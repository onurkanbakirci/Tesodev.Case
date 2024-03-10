using Tesodev.Case.Order.Domain.SeedWork;

namespace Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;

public interface IOrderRepository : IRepository<Order>
{
    /// <summary>
    /// Adds a new order to the system.
    /// </summary>
    /// <param name="order">The order to be added.</param>
    /// <returns>A task representing the operation that returns the added order.</returns>
    Task<Order> AddAsync(Order order);

    /// <summary>
    /// Updates an existing order.
    /// </summary>
    /// <param name="order">The order to be updated.</param>
    /// <returns>The updated order.</returns>
    Order Update(Order order);

    /// <summary>
    /// Deletes the current order.
    /// </summary>
    void Delete(Order order);

    /// <summary>
    /// Retrieves the order from the system.
    /// </summary>
    /// <returns>A task representing the operation that returns the order.</returns>
    Task<List<Order>> GetAsync();

    /// <summary>
    /// Retrieves the order from the system.
    /// </summary>
    /// <returns>A task representing the operation that returns the order.</returns>
    Task<Order> GetByIdAsync(Guid id);
}