using AutoMapper;
using OrderTest.Application.Mapping.Interfaces;
using OrderTest.Domain.Entities;

namespace OrderTest.Application.Models.ProductModels;

/// <summary>
/// Детали товара. (Get DTO).
/// </summary>
public class ProductDetails : IMapWith<Product>
{
    /// <summary>
    /// OID товара.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя товара.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Цена товара.
    /// </summary>
    public float Price { get; set; }

    /// <summary>
    /// Сопоставления Product и ProductDetails.
    /// </summary>
    /// <param name="profile">Профиль Automapper.</param>
    public void Mapping(Profile profile) =>
        profile.CreateMap<Product, ProductDetails>();
}