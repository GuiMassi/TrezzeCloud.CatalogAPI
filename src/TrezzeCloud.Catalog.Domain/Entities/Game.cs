namespace TrezzeCloud.Catalog.Domain.Entities;

public sealed class Game
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public string Category { get; private set; } = string.Empty;

    public string ImageUrl { get; private set; } = string.Empty;

    public DateTime DisponibilizationDate { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Game()
    {
    }

    public Game(
        string title,
        string description,
        decimal price,
        string category,
        string imageUrl,
        DateTime disponibilizationDate)
    {
        Id = Guid.NewGuid();

        Title = title;
        Description = description;
        Price = price;
        Category = category;
        ImageUrl = imageUrl;
        DisponibilizationDate = disponibilizationDate;

        IsActive = true;

        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string title,
        string description,
        decimal price,
        string category,
        string imageUrl,
        DateTime disponibilizationDate)
    {
        Title = title;
        Description = description;
        Price = price;
        Category = category;
        ImageUrl = imageUrl;
        DisponibilizationDate = disponibilizationDate;
    }

    public bool IsAvailable()
    {
        return IsActive && DisponibilizationDate <= DateTime.UtcNow;
    }

    public void Disable()
    {
        IsActive = false;
    }
}