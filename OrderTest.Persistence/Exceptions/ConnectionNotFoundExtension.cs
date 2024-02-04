namespace OrderTest.Persistence.Exceptions;

/// <summary>
/// Исключение при не найденном ключе подключения к БД.
/// </summary>
/// <param name="connectionNameKey">Ключ подключения в конфигурации.</param>
public class ConnectionNotFoundExtension(string connectionNameKey) 
    : Exception($"{connectionNameKey} connection not found");