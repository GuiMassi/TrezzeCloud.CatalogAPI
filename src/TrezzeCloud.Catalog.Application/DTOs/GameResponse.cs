namespace TrezzeCloud.Catalog.Application.DTOs;

public sealed record GameResponse(
    Guid Id,
    string Title,
    string Description,
    decimal Price,
    string Category,
    string ImageUrl,
    DateTime DisponibilizationDate,
    bool IsAvailable
);