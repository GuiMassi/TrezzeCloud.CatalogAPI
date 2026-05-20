using MassTransit;
using TrezzeCloud.Catalog.Api.Consumers;

namespace TrezzeCloud.Catalog.Api.Configurations;

public static class MassTransitConfiguration
{
    public static IServiceCollection AddMassTransitConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(config =>
        {
            config.AddConsumer<PaymentProcessedConsumer>();

            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(
                    configuration["RabbitMq:Host"]!,
                    "/",
                    host =>
                    {
                        host.Username(configuration["RabbitMq:Username"]!);
                        host.Password(configuration["RabbitMq:Password"]!);
                    });

                cfg.ReceiveEndpoint("catalog-payment-processed", endpoint =>
                {
                    endpoint.ConfigureConsumer<PaymentProcessedConsumer>(context);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}