namespace TrezzeCloud.Catalog.Application.DTOs;

public sealed record UpdateGameRequest(
    string Title,
    string Description,
    decimal Price,
    string Category,
    string ImageUrl
);