using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Versta24.Infrastructure.Data;
using Versta24.Infrastructure.Repositories;

namespace Versta24.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VerstaDbContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        return services;
    }
}