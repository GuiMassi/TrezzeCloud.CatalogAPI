namespace TrezzeCloud.Catalog.Domain.Entities;

public sealed class Game
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public string Category { get; private set; } = string.Empty;

    public string ImageUrl { get; private set; } = string.Empty;

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
        string imageUrl)
    {
        Id = Guid.NewGuid();

        Title = title;
        Description = description;
        Price = price;
        Category = category;
        ImageUrl = imageUrl;

        IsActive = true;

        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string title,
        string description,
        decimal price,
        string category,
        string imageUrl)
    {
        Title = title;
        Description = description;
        Price = price;
        Category = category;
        ImageUrl = imageUrl;
    }

    public void Disable()
    {
        IsActive = false;
    }
}