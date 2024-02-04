using Microsoft.Extensions.Caching.Memory;
using OrderTest.Application.Models.OrderDetails;
using OrderTest.Application.Services.Interfaces;

namespace OrderTest.Application.Services.Caching;

/// <summary>
/// Декортор сервиса работы с Заказами для кэширования в памяти.
/// </summary>
/// <param name="memoryCache">Кэш.</param>
/// <param name="service">Сервис работы с заказами (Конкретная реализация/DataAdapter/Decorator и и.д.)</param>
public class MemoryCacheOrderService(IMemoryCache memoryCache, IOrderService service) : IOrderService
{
    public async Task<OrderDetailsCollection> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var orderByUserCacheKey = $"order:{userId}";
        if (memoryCache.TryGetValue(orderByUserCacheKey, out OrderDetailsCollection? result)) return result!;
        result = await service.GetOrdersByUserIdAsync(userId, cancellationToken);
        memoryCache.Set(orderByUserCacheKey, result);
        return result;
    }

    public async Task<Guid> CreateOrderAsync(AddOrderDetails details, CancellationToken cancellationToken)
    {
        var orderByUserCacheKey = $"order:{details.UserId}";
        var result = await service.CreateOrderAsync(details, cancellationToken);
        memoryCache.Remove($"order:{details.UserId}");
        return result;
    }

    public async Task CancelOrderAsync(CancelOrderDetails details, CancellationToken cancellationToken)
    {
        var orderByUserCacheKey = $"order:{details.UserId}";
        await service.CancelOrderAsync(details, cancellationToken);
        memoryCache.Remove($"order:{details.UserId}");
    }
}