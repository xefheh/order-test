using AutoMapper;
using OrderTest.Application.Mapping.Interfaces;
using OrderTest.Domain.Entities;

namespace OrderTest.Application.Models.OrderDetails;

/// <summary>
/// Детали заказа. (Get DTO).
/// </summary>
public class OrderDetails : IMapWith<Order>
{
    /// <summary>
    /// OID заказа.
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
    /// Список деталий позиций заказов.
    /// </summary>
    public IList<OrderProductDetails> ProductPositions { get; set; }

    
    /// <summary>
    /// Сопоставление Order и OrderDetails.
    /// </summary>
    /// <param name="profile">Профиль Automapper.</param>
    public void Mapping(Profile profile) =>
        profile.CreateMap<Order, OrderDetails>();
}