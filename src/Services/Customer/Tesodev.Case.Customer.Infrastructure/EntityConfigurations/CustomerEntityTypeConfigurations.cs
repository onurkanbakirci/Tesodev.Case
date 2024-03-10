using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tesodev.Case.Customer.Infrastructure.EntityConfigurations;

public class CustomerEntityTypeConfigurations : IEntityTypeConfiguration<Domain.AggregatesModel.CustomerAggregate.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.AggregatesModel.CustomerAggregate.Customer> customerConfiguration)
    {
        customerConfiguration.ToTable("Customers");

        customerConfiguration.HasKey(o => o.Id);

        customerConfiguration
            .Property<string>("_email")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Email");

        customerConfiguration
            .Property<string>("_name")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Name");

        customerConfiguration.OwnsOne(o => o.Address, a =>
            {
                a.Property(n => n.AddressLine);
                a.Property(n => n.Country);
                a.Property(n => n.City);
                a.Property(n => n.CityCode);
                a.ToTable("Address");
                a.WithOwner().HasForeignKey(x => x.CustomerId);
            });
    }
}