using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderTest.Domain.Entities;

namespace OrderTest.Persistence.Configurations;

/// <summary>
/// Конфигурация сущности OrderProductPosition.
/// </summary>
public class OrderProductPositionTypeConfiguration : IEntityTypeConfiguration<OrderProductPosition>
{
    public void Configure(EntityTypeBuilder<OrderProductPosition> builder)
    {
        builder.HasKey(op => op.Id);
        builder.HasIndex(op => op.Id).IsUnique();
        builder.HasOne(p => p.Product);
    }
}