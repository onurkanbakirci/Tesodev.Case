using Tesodev.Case.Customer.Domain.SeedWork;

namespace Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

public interface ICustomerRepository : IRepository<Customer>
{
    /// <summary>
    /// Adds a new customer to the system.
    /// </summary>
    /// <param name="customer">The customer to be added.</param>
    /// <returns>A task representing the operation that returns the added customer.</returns>
    Task<Customer> AddAsync(Customer customer);

    /// <summary>
    /// Updates an existing customer.
    /// </summary>
    /// <param name="customer">The customer to be updated.</param>
    /// <returns>The updated customer.</returns>
    Customer Update(Customer customer);

    /// <summary>
    /// Deletes the current customer.
    /// </summary>
    void Delete(Customer customer);

    /// <summary>
    /// Retrieves the customer from the system.
    /// </summary>
    /// <returns>A task representing the operation that returns the customer.</returns>
    Task<List<Customer>> GetAsync();

    /// <summary>
    /// Retrieves the customer from the system.
    /// </summary>
    /// <returns>A task representing the operation that returns the customer.</returns>
    Task<Customer> GetByIdAsync(Guid id);
}