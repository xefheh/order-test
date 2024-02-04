using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderTest.Domain.Entities;

namespace OrderTest.Persistence.Configurations;

/// <summary>
/// Конфигурация сущности Order.
/// </summary>
public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasIndex(o => o.Id).IsUnique();
        builder.HasMany(o => o.ProductPositions)
            .WithOne(op => op.Order)
            .OnDelete(DeleteBehavior.Cascade);
    }
}