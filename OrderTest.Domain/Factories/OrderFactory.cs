using OrderTest.Domain.Entities;
using OrderTest.Domain.Factories.Interfaces;

namespace OrderTest.Domain.Factories;

/// <summary>
/// Реализация фабрики заказов.
/// </summary>
public class OrderFactory : IOrderFactory
{
    public Order CreateOrder(Guid userId, IEnumerable<ProductCountRecord> productCounts)
    {
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            CreationDate = DateTime.Now.ToUniversalTime(),
            UserId = userId,
            ProductPositions = new List<OrderProductPosition>()
        };
        
        foreach (var productCount in productCounts)
        {
            var orderProductPosition = new OrderProductPosition()
            {
                Count = productCount.Count,
                Product = productCount.Product,
                Price = productCount.Product.Price
            };
            order.ProductPositions.Add(orderProductPosition);
        }
        return order;
    }
}