using Microsoft.Extensions.Logging;
using OrderTest.Application.Exceptions;
using OrderTest.Application.Models.ProductModels;
using OrderTest.Application.Services.Interfaces;

namespace OrderTest.Application.Services.Logging;

/// <summary>
/// Декортор сервиса работы с Товарами для логгирования.
/// </summary>
/// <param name="logger">Логгер.</param>
/// <param name="service">Сервис работы с товарами (Конкретная реализация/DataAdapter/Decorator и и.д.)</param>
public class LogProductService(ILogger<IProductService> logger, IProductService service) : IProductService
{
    public async Task<ProductDetailsCollection> GetProductsAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("[PRODUCT SERVICE]. Invoked get of all products.");
        var products = await service.GetProductsAsync(cancellationToken);
        logger.LogInformation("[PRODUCT SERVICE]. Successful. Products: {@ProductList}, Count: {@Count}",
            products.ProductDetails, products.ProductDetails!.Count);
        return products;
    }

    public async Task<Guid> AddProductAsync(ProductAddDetails details, CancellationToken cancellationToken)
    {
        logger.LogInformation("[PRODUCT SERVICE]. Invoked add of product. Add details: {@Details}", details);
        var id = await service.AddProductAsync(details, cancellationToken);
        logger.LogInformation("[PRODUCT SERVICE]. Product added. Id: {@Id}", id);
        return id;
    }

    public async Task RemoveProductAsync(Guid id, CancellationToken cancellationToken)
    {
        logger.LogInformation("[PRODUCT SERVICE]. Invoked remove of product. Id: {@Id}", id);
        try
        {
            await service.RemoveProductAsync(id, cancellationToken);
            logger.LogInformation("[PRODUCT SERVICE]. Successful. Product with Id: {@Id} deleted", id);
        }
        catch (NotFoundException e)
        {
            logger.LogError("[PRODUCT SERVICE]. Error occured: {@Exception}", e);
            throw;
        }
    }
}