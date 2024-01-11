using Microsoft.EntityFrameworkCore;
using Versta24.Infrastructure.Data;

namespace Versta24.Api.Extensions;

public class DatabaseExtensions
{
    public static void MigrateDatabase(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetService<VerstaDbContext>();

            int maxAttempts = 3;
            int attemptCount = 0;
            int delay = 5;
            
            while (attemptCount < maxAttempts)
            {
                try
                {
                    
                    context.Database.Migrate();
                    break;
                }
                catch (Exception e)
                {
                    
                    attemptCount++; 
                    Task.Delay(TimeSpan.FromSeconds(delay)).Wait();
                    delay += 5;
                }
            }
        }
    }
}