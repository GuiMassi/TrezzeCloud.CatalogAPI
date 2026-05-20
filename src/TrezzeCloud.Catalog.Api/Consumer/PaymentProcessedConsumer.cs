using MassTransit;
using Microsoft.EntityFrameworkCore;
using TrezzeCloud.Catalog.Domain.Entities;
using TrezzeCloud.Catalog.Infrastructure.Data;
using TrezzeCloud.Contracts.Events;

namespace TrezzeCloud.Catalog.Api.Consumers;

public sealed class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
{
    private readonly CatalogDbContext _context;

    public PaymentProcessedConsumer(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        if (context.Message.Status != "Approved")
            return;

        var alreadyOwned = await _context.UserLibraries
            .AnyAsync(x =>
                x.UserId == context.Message.UserId &&
                x.GameId == context.Message.GameId);

        if (alreadyOwned)
            return;

        var library = new UserLibrary(
            context.Message.UserId,
            context.Message.GameId);

        await _context.UserLibraries.AddAsync(library);

        await _context.SaveChangesAsync();

        Console.WriteLine("====================================");
        Console.WriteLine("GAME ADDED TO LIBRARY");
        Console.WriteLine($"User: {context.Message.UserId}");
        Console.WriteLine($"Game: {context.Message.GameId}");
        Console.WriteLine("====================================");
    }
}