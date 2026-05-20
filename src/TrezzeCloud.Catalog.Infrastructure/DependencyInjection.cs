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
                configuration.GetConnectionString("CatalogDatabase"));
        });

        return services;
    }
}