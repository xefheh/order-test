using OrderTest.Application.Models.OrderDetails;

namespace OrderTest.Application.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса работы с сущностью Заказ.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Асинхронно получить заказы пользователя по его OID.
    /// </summary>
    /// <param name="userId">OID пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция деталей товаров.</returns>
    Task<OrderDetailsCollection> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронно создать заказ по деталям.
    /// </summary>
    /// <param name="details">Детали создания заказа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OID заказа.</returns>
    Task<Guid> CreateOrderAsync(AddOrderDetails details, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронно отменить заказ по деталям.
    /// </summary>
    /// <param name="details">Детали отмены заказа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пустой Task.</returns>
    Task CancelOrderAsync(CancelOrderDetails details, CancellationToken cancellationToken);
}