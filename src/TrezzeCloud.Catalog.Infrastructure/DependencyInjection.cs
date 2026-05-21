using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrezzeCloud.Catalog.Infrastructure.Data;

namespace TrezzeCloud.Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("CatalogDatabase"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null);
                });
        });

        return services;
    }

    public static async Task MigrateDatabaseAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();

        const int maxAttempts = 10;
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                await dbContext.Database.MigrateAsync();
                break;
            }
            catch when (attempt < maxAttempts)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }
    }
}