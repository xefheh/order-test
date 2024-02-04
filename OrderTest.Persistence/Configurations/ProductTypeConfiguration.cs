using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderTest.Domain.Entities;

namespace OrderTest.Persistence.Configurations;

/// <summary>
/// Конфигурация сущности Product.
/// </summary>
public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Id)
            .IsUnique();
        builder.Property(p => p.Name)
            .HasMaxLength(125);
    }
}