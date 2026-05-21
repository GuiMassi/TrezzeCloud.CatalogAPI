using FluentAssertions;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using TrezzeCloud.Catalog.Api.Consumers;
using TrezzeCloud.Catalog.Api.Controllers;
using TrezzeCloud.Catalog.Application.DTOs;
using TrezzeCloud.Catalog.Domain.Entities;
using TrezzeCloud.Catalog.Infrastructure.Data;
using TrezzeCloud.Contracts.Events;

namespace TrezzeCloud.Catalog.UnitTests;

public sealed class CatalogFlowTests
{
    [Fact]
    public async Task Should_Create_Game()
    {
        await using var context = CreateDbContext();
        var sut = new GameController(context);

        var request = new CreateGameRequest(
            "Cyber Drift",
            "Arcade racing game",
            99.90m,
            "Racing",
            "https://img/game.png");

        var result = await sut.Create(request);

        var createdResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
        createdResult.ActionName.Should().Be(nameof(GameController.GetById));

        context.Games.Should().HaveCount(1);
        var game = await context.Games.SingleAsync();
        game.Title.Should().Be("Cyber Drift");
        game.Price.Should().Be(99.90m);
    }

    [Fact]
    public async Task Should_Add_Game_To_Library_When_Payment_Approved()
    {
        await using var context = CreateDbContext();
        var sut = new PaymentProcessedConsumer(context);

        var userId = Guid.NewGuid();
        var gameId = Guid.NewGuid();

        var message = new PaymentProcessedEvent(
            Guid.NewGuid(),
            userId,
            gameId,
            39.90m,
            "Approved",
            DateTime.UtcNow);

        var consumeContextMock = new Mock<ConsumeContext<PaymentProcessedEvent>>();
        consumeContextMock.Setup(x => x.Message).Returns(message);

        await sut.Consume(consumeContextMock.Object);

        context.UserLibraries.Should().HaveCount(1);
        var libraryItem = await context.UserLibraries.SingleAsync();
        libraryItem.UserId.Should().Be(userId);
        libraryItem.GameId.Should().Be(gameId);
    }

    [Fact]
    public async Task Should_Not_Add_Duplicate_Game()
    {
        await using var context = CreateDbContext();
        var sut = new PaymentProcessedConsumer(context);

        var userId = Guid.NewGuid();
        var gameId = Guid.NewGuid();

        await context.UserLibraries.AddAsync(new UserLibrary(userId, gameId));
        await context.SaveChangesAsync();

        var message = new PaymentProcessedEvent(
            Guid.NewGuid(),
            userId,
            gameId,
            39.90m,
            "Approved",
            DateTime.UtcNow);

        var consumeContextMock = new Mock<ConsumeContext<PaymentProcessedEvent>>();
        consumeContextMock.Setup(x => x.Message).Returns(message);

        await sut.Consume(consumeContextMock.Object);

        context.UserLibraries.Should().HaveCount(1);
    }

    private static CatalogDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<CatalogDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new CatalogDbContext(options);
    }
}
