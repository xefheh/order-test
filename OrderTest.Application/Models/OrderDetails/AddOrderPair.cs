namespace OrderTest.Application.Models.OrderDetails;

/// <summary>
/// Вспомогательный DTO. Пара типа OID продукта - количество.
/// </summary>
public class AddOrderPair
{
    /// <summary>
    /// OID продукта.
    /// </summary>
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Количество.
    /// </summary>
    public int Count { get; set; }
}