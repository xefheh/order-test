namespace OrderTest.Domain.Entities;

/// <summary>
/// Сущность заказа.
/// </summary>
public class Order
{
    /// <summary>
    /// OID.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// OID пользователя.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Дата создания заказа.
    /// </summary>
    public DateTime CreationDate { get; set; }
    
    /// <summary>
    /// Список позиций заказа.
    /// </summary>
    public virtual IList<OrderProductPosition>? ProductPositions { get; set; }
}