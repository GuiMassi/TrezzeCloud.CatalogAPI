namespace TrezzeCloud.Catalog.Application.DTOs;

public sealed record CreateGameRequest(
    string Title,
    string Description,
    decimal Price,
    string Category,
    string ImageUrl,
    DateTime DisponibilizationDate
);