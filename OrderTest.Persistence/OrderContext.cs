using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OrderTest.Application.Interfaces;
using OrderTest.Domain.Entities;

namespace OrderTest.Persistence;

public class OrderContext(DbContextOptions<OrderContext> options) : DbContext(options), IOrderContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProductPosition> OrderProductPositions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}