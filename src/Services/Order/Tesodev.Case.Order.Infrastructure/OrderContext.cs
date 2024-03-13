using Tesodev.Case.Order.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tesodev.Case.Order.Infrastructure.EntityConfigurations;
using Tesodev.Case.Order.Infrastructure.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;

namespace Tesodev.Case.Order.Infrastructure;

public class OrderContext : DbContext, IUnitOfWork
{
    public DbSet<Domain.AggregatesModel.OrderAggregate.Order> Orders { get; set; }
    private IDbContextTransaction _currentTransaction;
    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
    public bool HasActiveTransaction => _currentTransaction != null;
    public OrderContext()
    {
    }

    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = ServiceTool.ServiceProvider?.GetService<IConfiguration>()?.GetSection("DatabaseConfigurations:ConnectionString")?.Value;
        optionsBuilder.UseNpgsql(connection!);
        base.OnConfiguring(optionsBuilder);
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync();

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            transaction.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}

public class OrderContextDesignFactory : IDesignTimeDbContextFactory<OrderContext>
{
    public OrderContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderContext>().UseNpgsql("Host=localhost;Port=5432;Database=Tesodev.Orders;Username=postgres;Password=root");
        return new OrderContext(optionsBuilder.Options);
    }
}