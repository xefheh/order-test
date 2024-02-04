namespace OrderTest.Application.Models.OrderDetails;

/// <summary>
/// Коллекция деталей заказа. (Get DTO).
/// </summary>
public class OrderDetailsCollection
{
    /// <summary>
    /// Список деталей заказа.
    /// </summary>
    public IList<OrderDetails>? OrderDetails { get; set; }
}