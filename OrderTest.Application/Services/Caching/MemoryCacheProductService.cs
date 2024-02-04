using Microsoft.Extensions.Caching.Memory;
using OrderTest.Application.Models.ProductModels;
using OrderTest.Application.Services.Interfaces;

namespace OrderTest.Application.Services.Caching;

/// <summary>
/// Декортор сервиса работы с Товарами для кэширования в памяти.
/// </summary>
/// <param name="memoryCache">Кэш.</param>
/// <param name="service">Сервис работы с товарами (Конкретная реализация/DataAdapter/Decorator и и.д.)</param>
public class MemoryCacheProductService(IMemoryCache memoryCache, IProductService service) : IProductService
{
    public async Task<ProductDetailsCollection> GetProductsAsync(CancellationToken cancellationToken)
    {
        const string allProductsCacheKey = "products:all";
        if (memoryCache.TryGetValue(allProductsCacheKey, out ProductDetailsCollection? result)) return result!;
        result = await service.GetProductsAsync(cancellationToken);
        memoryCache.Set(allProductsCacheKey, result);
        return result;
    }

    public async Task<Guid> AddProductAsync(ProductAddDetails details, CancellationToken cancellationToken)
    {
        var result = await service.AddProductAsync(details, cancellationToken);
        memoryCache.Remove("products:all");
        return result;
    }

    public async Task RemoveProductAsync(Guid id, CancellationToken cancellationToken)
    {
        await service.RemoveProductAsync(id, cancellationToken);
        memoryCache.Remove("products:all");
    }
}