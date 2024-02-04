namespace OrderTest.Application.Models.OrderDetails;

/// <summary>
/// Детали добавления заказа. (Add DTO).
/// </summary>
public class AddOrderDetails
{
    /// <summary>
    /// OID Пользователя.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Коллекция пар типа OID Товара - Количество.
    /// </summary>
    public IList<AddOrderPair> AddOrderPairs { get; set; }
}