namespace OrderTest.Domain.Entities;

/// <summary>
/// Сущность позиции товара в заказе.
/// </summary>
public class OrderProductPosition
{
    /// <summary>
    /// OID.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Цена товара (на момент создания заказа).
    /// </summary>
    public float Price { get; set; }
    
    /// <summary>
    /// Количество товара в заказе.
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Товар в позиции.
    /// </summary>
    public virtual Product Product { get; set; } = null!;
    
    /// <summary>
    /// Навигационное свойство на заказ.
    /// </summary>
    public virtual Order Order { get; set; } = null!;
}