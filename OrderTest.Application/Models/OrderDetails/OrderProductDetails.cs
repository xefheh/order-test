using AutoMapper;
using OrderTest.Application.Mapping.Interfaces;
using OrderTest.Domain.Entities;

namespace OrderTest.Application.Models.OrderDetails;

/// <summary>
/// Детали позиции заказа. (Get DTO).
/// </summary>
public class OrderProductDetails : IMapWith<OrderProductPosition>
{
    /// <summary>
    /// Цена товара (на момент создания заказа).
    /// </summary>
    public float Price { get; set; }
    
    /// <summary>
    /// Количество.
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// OID товара.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Сопоставления OrderProductPosition, OrderProductDetails.
    /// </summary>
    /// <param name="profile">Профиль Automapper.</param>
    public void Mapping(Profile profile) =>
        profile.CreateMap<OrderProductPosition, OrderProductDetails>()
            .ForMember(opt => opt.ProductId,
                dest => dest.MapFrom(o =>
                    o.Product.Id));
}