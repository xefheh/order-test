using OrderTest.Domain.Entities;
using OrderTest.Domain.Factories;
using OrderTest.Domain.Factories.Interfaces;

namespace OrderTest.Domain.Tests;

public class OrderFactoryTests
{
    private IOrderFactory _factory;

    [SetUp]
    public void SetUp()
    {
        _factory = new OrderFactory();
    }
    
    [Test]
    public void Create_Order_Test()
    {
        var productA = new Product { Id = Guid.Empty, Name = "A", Price = 500 };
        var productB = new Product { Id = Guid.Empty, Name = "B", Price = 2100 };
        var productC = new Product { Id = Guid.Empty, Name = "C", Price = 6700 };
        List<ProductCountRecord> records =
        [
            new ProductCountRecord(productA, 5),
            new ProductCountRecord(productB, 2),
            new ProductCountRecord(productC, 4)
        ];
        var order = _factory.CreateOrder(Guid.Empty, records);
        order.Id = Guid.Empty;
        order.CreationDate = DateTime.MinValue;
        var expected = new Order()
        {
            Id = Guid.Empty,
            CreationDate = DateTime.MinValue,
            UserId = Guid.Empty,
            ProductPositions = [
            new OrderProductPosition() { Id = 0,}]
        }
    }
}