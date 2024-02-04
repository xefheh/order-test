using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OrderTest.Application.Mapping;
using OrderTest.Application.Services;
using OrderTest.Application.Services.Caching;
using OrderTest.Application.Services.Interfaces;
using OrderTest.Application.Services.Logging;
using OrderTest.Domain.Factories;
using OrderTest.Domain.Factories.Interfaces;

namespace OrderTest.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Подключения слоя Application.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderFactory, OrderFactory>();
        services.AddAutoMapper(conf =>
            conf.AddProfile(new AssemblyMappingProfile(
                Assembly.GetExecutingAssembly())));
    }

    /// <summary>
    /// Подключение логирования в Application слое.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddApplicationLogging(this IServiceCollection services)
    {
        services.Decorate<IProductService, LogProductService>();
        services.Decorate<IOrderService, LogOrderService>();
    }
    
    /// <summary>
    /// Подключение кэширования в Application слое.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddApplicationCaching(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.Decorate<IProductService, MemoryCacheProductService>();
        services.Decorate<IOrderService, MemoryCacheOrderService>();
    }
}