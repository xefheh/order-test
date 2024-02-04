using System.Reflection;
using AutoMapper;
using OrderTest.Application.Mapping.Interfaces;

namespace OrderTest.Application.Mapping;

/// <summary>
/// Общий для сборки Automapper профиль.
/// </summary>
public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly)
        => ApplyMappingsFromAssembly(assembly);

    /// <summary>
    /// Применить профили сопоставления из сборки.
    /// </summary>
    /// <param name="assembly">Сборка, где брать профили.</param>
    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();
        
        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, [this]);
        }
    }
}