namespace OrderTest.Application.Exceptions;

/// <summary>
/// Исключение о ненайденном объекте.
/// </summary>
/// <param name="name">Имя класса. (nameof).</param>
/// <param name="key">Ненайденный ключ.</param>
public class NotFoundException(string name, object key) 
    : Exception($"{name} with key {key} not found!");