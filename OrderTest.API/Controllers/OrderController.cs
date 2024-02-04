using Microsoft.AspNetCore.Mvc;
using OrderTest.API.Controllers.Abstraction;
using OrderTest.Application.Models.OrderDetails;
using OrderTest.Application.Services.Interfaces;

namespace OrderTest.API.Controllers;

/// <summary>
/// Контроллер заказов.
/// </summary>
/// <param name="orderService">Сервис заказов.</param>
public class OrderController(IOrderService orderService) : BaseController
{
    /// <summary>
    /// Get-метод получения заказов.
    /// </summary>
    /// <param name="userId">OID пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция деталей заказов.</returns>
    [HttpGet("{userId:guid}")]
    public async Task<OrderDetailsCollection> Get(Guid userId, CancellationToken cancellationToken) =>
        await orderService.GetOrdersByUserIdAsync(userId, cancellationToken);

    /// <summary>
    /// Post-метод создания заказа.
    /// </summary>
    /// <param name="details">Детали для создания заказа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OID заказа.</returns>
    [HttpPost]
    public async Task<Guid> Post([FromBody] AddOrderDetails details, CancellationToken cancellationToken) =>
        await orderService.CreateOrderAsync(details, cancellationToken);

    /// <summary>
    /// Delete-метод отмены заказа.
    /// </summary>
    /// <param name="deleteDetails">Детали для отмены заказа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete]
    public async Task Delete([FromQuery] CancelOrderDetails deleteDetails, CancellationToken cancellationToken) =>
        await orderService.CancelOrderAsync(deleteDetails, cancellationToken);
}