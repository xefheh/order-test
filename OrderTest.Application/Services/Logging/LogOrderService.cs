using Microsoft.Extensions.Logging;
using OrderTest.Application.Exceptions;
using OrderTest.Application.Models.OrderDetails;
using OrderTest.Application.Services.Interfaces;

namespace OrderTest.Application.Services.Logging;

/// <summary>
/// Декортор сервиса работы с Заказами для логгирования.
/// </summary>
/// <param name="logger">Логгер.</param>
/// <param name="service">Сервис работы с заказами (Конкретная реализация/DataAdapter/Decorator и и.д.)</param>
public class LogOrderService(ILogger<IOrderService> logger, IOrderService service) : IOrderService
{
    public async Task<OrderDetailsCollection> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        logger.LogInformation("[ORDER SERVICE]. Invoked get of all products by user id: {@UserId}.", userId);
        var orders = await service.GetOrdersByUserIdAsync(userId, cancellationToken);
        logger.LogInformation("[ORDER SERVICE]. Successful. UserId: {@UserId}, Items: {@Items}, Collection count: {@Count}",
            userId, orders.OrderDetails, orders.OrderDetails!.Count);
        return orders;
    }

    public async Task<Guid> CreateOrderAsync(AddOrderDetails details, CancellationToken cancellationToken)
    {
        logger.LogInformation("[ORDER SERVICE]. Invoked create order with details: {@Details}.", details);
        try
        {
            var id = await service.CreateOrderAsync(details, cancellationToken);
            logger.LogInformation("[ORDER SERVICE]. Successful. Id of new order: {@Id}", id);
            return id;
        }
        catch (NotFoundException e)
        {
            logger.LogError("[ORDER SERVICE]. Error occured: {@Exception}", e);
            throw;
        }
    }

    public async Task CancelOrderAsync(CancelOrderDetails details, CancellationToken cancellationToken)
    {
        logger.LogInformation("[ORDER SERVICE]. Invoked cancel order with cancel details: {@Details}.", details);
        try
        {
            await service.CancelOrderAsync(details, cancellationToken);
            logger.LogInformation("[ORDER SERVICE]. Successful. Order with details: {@Details} canceled", details);
        }
        catch (NotFoundException e)
        {
            logger.LogError("[ORDER SERVICE]. Error occured: {@Exception}", e);
            throw;
        }
    }
}