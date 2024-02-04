using Microsoft.AspNetCore.Mvc;
using OrderTest.API.Controllers.Abstraction;
using OrderTest.Application.Models.ProductModels;
using OrderTest.Application.Services.Interfaces;

namespace OrderTest.API.Controllers;

/// <summary>
/// Контроллер товаров.
/// </summary>
/// <param name="service">Сервис товаров.</param>
public class ProductController(IProductService service) : BaseController
{
    /// <summary>
    /// Get-метод получения списка товаров.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция деталей товаров.</returns>
    [HttpGet]
    public async Task<ProductDetailsCollection> Get(CancellationToken cancellationToken) =>
        await service.GetProductsAsync(cancellationToken);

    /// <summary>
    /// Post-метод доблавения товара.
    /// </summary>
    /// <param name="details">Детали товара.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OID товара.</returns>
    [HttpPost]
    public async Task<Guid> Post([FromBody] ProductAddDetails details, CancellationToken cancellationToken) =>
        await service.AddProductAsync(details, cancellationToken);

    /// <summary>
    /// Delete-метод удаления товара.
    /// </summary>
    /// <param name="id">OID товара.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id, CancellationToken cancellationToken) =>
        await service.RemoveProductAsync(id, cancellationToken);
}