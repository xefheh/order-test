namespace OrderTest.Application.Models.ProductModels;

/// <summary>
/// Детали добавления товара. (Add DTO).
/// </summary>
public class ProductAddDetails
{
    /// <summary>
    /// Имя товара.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Цена товара.
    /// </summary>
    public float Price { get; set; }
}