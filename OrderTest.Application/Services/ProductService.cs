using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OrderTest.Application.Exceptions;
using OrderTest.Application.Interfaces;
using OrderTest.Application.Models.ProductModels;
using OrderTest.Application.Services.Interfaces;
using OrderTest.Domain.Entities;

namespace OrderTest.Application.Services;

/// <summary>
/// Конкретная реализация сервиса для работы с сущностью Товар.
/// </summary>
/// <param name="mapper">Маппер.</param>
/// <param name="context">Контекст БД.</param>
public class ProductService(IMapper mapper, IOrderContext context) : IProductService
{
    public async Task<ProductDetailsCollection> GetProductsAsync(CancellationToken cancellationToken)
    {
        var productDetails = await context.Products
            .ProjectTo<ProductDetails>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new ProductDetailsCollection() { ProductDetails = productDetails };
    }

    public async Task<Guid> AddProductAsync(ProductAddDetails details, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = details.Name,
            Price = details.Price
        };
        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }

    public async Task RemoveProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (product == null) throw new NotFoundException(nameof(Product), id);
        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}