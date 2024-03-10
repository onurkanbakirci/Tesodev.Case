using Tesodev.Case.Customer.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Customer.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public object EntityState { get; private set; }

    public CustomerRepository(CustomerContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="customer"><inheritdoc/></param>
    /// <returns><inheritdoc/></returns>
    public async Task<Domain.AggregatesModel.CustomerAggregate.Customer> AddAsync(Domain.AggregatesModel.CustomerAggregate.Customer customer)
    {
        return (await _context.Customers.AddAsync(customer)).Entity;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public async void Delete(Domain.AggregatesModel.CustomerAggregate.Customer customer)
    {
        _context.Customers.Remove(customer);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public async Task<List<Domain.AggregatesModel.CustomerAggregate.Customer>> GetAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public async Task<Domain.AggregatesModel.CustomerAggregate.Customer> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="customer"><inheritdoc/></param>
    /// <returns><inheritdoc/></returns>
    public Domain.AggregatesModel.CustomerAggregate.Customer Update(Domain.AggregatesModel.CustomerAggregate.Customer customer)
    {
        _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return customer;
    }
}