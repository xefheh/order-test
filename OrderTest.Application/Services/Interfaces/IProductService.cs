using OrderTest.Application.Models.ProductModels;

namespace OrderTest.Application.Services.Interfaces;

/// <summary>
/// Интерфейс сервисы работы с сущностью Товар.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Асинхронно получить список всех товаров.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция деталей товаров.</returns>
    Task<ProductDetailsCollection> GetProductsAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронно добавить новый товар.
    /// </summary>
    /// <param name="details">Детали добавления товара.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OID товара.</returns>
    Task<Guid> AddProductAsync(ProductAddDetails details, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное удаление товара.
    /// </summary>
    /// <param name="id">OID товара.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пустой Task.</returns>
    Task RemoveProductAsync(Guid id, CancellationToken cancellationToken);
}