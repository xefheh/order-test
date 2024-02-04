using AutoMapper;

namespace OrderTest.Application.Mapping.Interfaces;

/// <summary>
/// Интерфейс указывающий на Mapping с конкретным объектом.
/// </summary>
/// <typeparam name="T">С каким объектом идёт Mapping.</typeparam>
public interface IMapWith<T>
{
    /// <summary>
    /// Метод для сопоставления имплиментирующего интерфейс объекта и указанного в generic-параметре. 
    /// </summary>
    /// <param name="profile">Профиль Automapper.</param>
    public void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}