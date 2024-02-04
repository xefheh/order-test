using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OrderTest.Application.Models.ProductModels;

/// <summary>
/// Коллекция деталей товаров. (Get DTO).
/// </summary>
public class ProductDetailsCollection
{
    
    /// <summary>
    /// Список деталей товаров.
    /// </summary>
    public IList<ProductDetails>? ProductDetails { get; set; }
}