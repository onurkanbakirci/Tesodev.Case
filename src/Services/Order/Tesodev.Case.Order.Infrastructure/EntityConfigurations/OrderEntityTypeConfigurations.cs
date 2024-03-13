using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tesodev.Case.Order.Infrastructure.EntityConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.OrderAggregate.Order>
{
    public void Configure(EntityTypeBuilder<Domain.AggregatesModel.OrderAggregate.Order> orderConfiguration)
    {
        orderConfiguration.ToTable("Orders");

        orderConfiguration.HasKey(o => o.Id);

        orderConfiguration
            .Property<int>("_quantity")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Quantity");

        orderConfiguration
            .Property<Guid>("_customerId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CustomerId");

        orderConfiguration
            .Property<double>("_price")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Price");

        orderConfiguration
            .Property<string>("_status")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Status");

        orderConfiguration.Property(o => o.CreatedAt).HasColumnName("CreatedAt").HasDefaultValueSql("NOW()");

        orderConfiguration.Property(o => o.UpdatedAt).HasColumnName("UpdatedAt").HasDefaultValueSql("NOW()");

        orderConfiguration.OwnsOne(o => o.Address, a =>
            {
                a.Property(n => n.AddressLine);
                a.Property(n => n.Country);
                a.Property(n => n.City);
                a.Property(n => n.CityCode);
                a.ToTable("Address");
                a.WithOwner().HasForeignKey(x => x.OrderId);
            });

        orderConfiguration.OwnsOne(o => o.Product, a =>
           {
               a.Property(n => n.ProductId);
               a.Property(n => n.Name);
               a.Property(n => n.ImageUrl);
               a.ToTable("Products");
               a.WithOwner().HasForeignKey(x => x.OrderId);
           });
    }
}