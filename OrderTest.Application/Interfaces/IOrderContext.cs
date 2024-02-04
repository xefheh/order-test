using Microsoft.EntityFrameworkCore;
using OrderTest.Domain.Entities;

namespace OrderTest.Application.Interfaces;

/// <summary>
/// Интерфейс контекста БД (для Application Layer)
/// </summary>
public interface IOrderContext
{
    /// <summary>
    /// Товары.
    /// </summary>
    DbSet<Product> Products { get; set; }
    
    /// <summary>
    /// Заказы.
    /// </summary>
    DbSet<Order> Orders { get; set; }
    
    /// <summary>
    /// Позиции товаров в заказе.
    /// </summary>
    DbSet<OrderProductPosition> OrderProductPositions { get; set; }
    
    /// <summary>
    /// Сохранить БД асинхронно.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Код сохранения.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}