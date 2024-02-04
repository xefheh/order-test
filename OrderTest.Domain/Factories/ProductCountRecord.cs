using OrderTest.Domain.Entities;

namespace OrderTest.Domain.Factories;

/// <summary>
/// Пара типа Товар - Количество.
/// </summary>
/// <param name="Product">Конкретный товар.</param>
/// <param name="Count">Количество товара.</param>
public record struct ProductCountRecord(Product Product, int Count);