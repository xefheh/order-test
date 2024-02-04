using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OrderTest.Application.Exceptions;
using OrderTest.Application.Interfaces;
using OrderTest.Application.Models.OrderDetails;
using OrderTest.Application.Services.Interfaces;
using OrderTest.Domain.Entities;
using OrderTest.Domain.Factories;
using OrderTest.Domain.Factories.Interfaces;

namespace OrderTest.Application.Services;

/// <summary>
/// Конкретная реализация сервиса для работы с сущностью Заказ.
/// </summary>
/// <param name="orderFactory">Фабрика заказов.</param>
/// <param name="context">Контекст БД.</param>
/// <param name="mapper">Маппер.</param>
public class OrderService(IOrderFactory orderFactory, IOrderContext context, IMapper mapper) : IOrderService
{
    public async Task<OrderDetailsCollection> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var orders = await context.Orders
            .Where(o => o.UserId == userId)
            .ProjectTo<OrderDetails>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new OrderDetailsCollection() { OrderDetails = orders };
    }

    public async Task<Guid> CreateOrderAsync(AddOrderDetails details, CancellationToken cancellationToken)
    {
        var productCountRecords = new List<ProductCountRecord>();
        foreach (var pair in details.AddOrderPairs)
        {
            var product = await context.Products
                .FirstOrDefaultAsync(p => p.Id == pair.ProductId, cancellationToken);
            if (product == null) throw new NotFoundException(nameof(Product), pair.ProductId);
            var record = new ProductCountRecord(product, pair.Count);
            productCountRecords.Add(record);
        }
        var order = orderFactory.CreateOrder(details.UserId, productCountRecords);
        await context.Orders.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return order.Id;
    }

    public async Task CancelOrderAsync(CancelOrderDetails details, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .FirstOrDefaultAsync(o => o.Id == details.Id, cancellationToken);
        if (order == null || details.UserId != order.UserId) throw new NotFoundException(nameof(Order), details.Id);
        context.Orders.Remove(order);
        await context.SaveChangesAsync(cancellationToken);
    }
}