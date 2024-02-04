namespace OrderTest.Application.Models.OrderDetails;

/// <summary>
/// Детали отмены заказа. (Delete DTO).
/// </summary>
public class CancelOrderDetails
{
    /// <summary>
    /// OID Заказа.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// OID Пользователя.
    /// </summary>
    public Guid UserId { get; set; }
}