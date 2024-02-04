using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderTest.Application.Interfaces;
using OrderTest.Domain.Entities;
using OrderTest.Persistence.Exceptions;

namespace OrderTest.Persistence;

public static class DependencyInjection
{
    /// <summary>
    /// Добавить Persistence-слой приложения в IoC-контейнер.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <param name="configuration">Класс конфигурации.</param>
    /// <exception cref="ConnectionNotFoundExtension">Исключительная ситуация: не найдено полдключение</exception>
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        const string connectionKey = "Order.db.connection";
        var connectionString = configuration.GetConnectionString(connectionKey);
        if (connectionString == null) throw new ConnectionNotFoundExtension(connectionKey);
        services.AddDbContext<OrderContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IOrderContext, OrderContext>();
    }

    /// <summary>
    /// Пересоздать базу данных (Удалить -> создать) по заданной конфигурации.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <exception cref="NullReferenceException">Исключительная ситуация: Контекст БД - null</exception>
    public static void RecreateDatabase(this IServiceCollection services)
    {
        using var provider = services.BuildServiceProvider();
        var context = provider.GetService<OrderContext>();
        if (context == null) throw new NullReferenceException();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    /// <summary>
    /// Наполнить БД тестовыми данными.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <exception cref="NullReferenceException">Исключительная ситуация: Контентекст БД - null </exception>
    public static void FillTestData(this IServiceCollection services)
    {
        using var provider = services.BuildServiceProvider();
        var context = provider.GetService<OrderContext>();
        if (context == null) throw new NullReferenceException();
        var products = new[]
        {
            (new Product() { Id = Guid.Parse("2f43d287-ce30-4fc1-82f5-3de7082c41d6"), Name = "Молоко", Price = 79.99f }),
            (new Product() { Id = Guid.Parse("7dd2a158-2b62-4245-86a2-19237e2aa404"), Name = "Колбаса", Price = 255.5f}),
            (new Product() { Id = Guid.Parse("db166cc6-76a1-4827-91a4-5a807670a8f3"), Name = "Сыр", Price = 125.5f})
        };
        
        var orders = new[]
        {
            (new Order()
            {
                Id = Guid.Parse("80a08d08-84a7-409e-8236-74c496f9ebaa"),
                UserId = Guid.Parse("80a08d08-84a7-409e-8236-74c496f9ebac"),
                CreationDate = DateTime.Now.ToUniversalTime(),
                ProductPositions = new List<OrderProductPosition>()
                {
                    new OrderProductPosition() { Product = products[0], Price = products[0].Price, Count = 200 },
                    new OrderProductPosition() { Product = products[1], Price = products[1].Price, Count = 255 },
                    new OrderProductPosition() { Product = products[2], Price = products[2].Price, Count = 220 }
                }
            })
        };
        
        context.Products.AddRange(products);
        context.Orders.AddRange(orders);
        context.SaveChanges();
    }
}