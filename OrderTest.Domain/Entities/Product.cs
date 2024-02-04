namespace OrderTest.Domain.Entities;

/// <summary>
/// Сущность товара.
/// </summary>
public class Product
{
    /// <summary>
    /// OID.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название товара.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Цена товара.
    /// </summary>
    public float Price { get; set; }
}