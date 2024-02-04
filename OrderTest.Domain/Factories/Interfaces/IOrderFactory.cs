using OrderTest.Domain.Entities;

namespace OrderTest.Domain.Factories.Interfaces;

/// <summary>
/// Интерфейс фабрики заказов.
/// </summary>
public interface IOrderFactory
{
    /// <summary>
    /// Создать заказ.
    /// </summary>
    /// <param name="userId">OID пользователя.</param>
    /// <param name="productCounts">Записи типа Товар - Количество.</param>
    /// <returns>Созданный заказ.</returns>
    Order CreateOrder(Guid userId, IEnumerable<ProductCountRecord> productCounts);
}