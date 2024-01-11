using Microsoft.Extensions.DependencyInjection;
using Versta24.Application.AutoMapperConfig;
using Versta24.Application.Services;

namespace Versta24.Application;

public static class DI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapProfile));
        services.AddScoped<IOrderService, OrderService>();
        
        return services;
    }
}