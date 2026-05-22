using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrezzeCloud.Catalog.Domain.Entities;

namespace TrezzeCloud.Catalog.Infrastructure.Configurations;

public sealed class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Category)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.DisponibilizationDate)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasData(
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                Title = "Skyward Legends",
                Description = "RPG de aventura em ilhas flutuantes com foco em exploração.",
                Price = 129.90m,
                Category = "RPG",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/skyward-legends.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                Title = "Neon Sprint",
                Description = "Corridas urbanas de alta velocidade com trilha eletrônica intensa.",
                Price = 89.90m,
                Category = "Racing",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/neon-sprint.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111103"),
                Title = "Iron Tactics",
                Description = "Estratégia tática por turnos com batalhas em larga escala.",
                Price = 99.50m,
                Category = "Strategy",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/iron-tactics.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 3, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 3, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111104"),
                Title = "Mystic Valley",
                Description = "Simulação de fazenda mágica com crafting e missões cooperativas.",
                Price = 74.00m,
                Category = "Simulation",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/mystic-valley.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 4, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 4, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111105"),
                Title = "Deep Signal",
                Description = "Thriller sci-fi com investigação em uma estação submersa.",
                Price = 109.00m,
                Category = "Adventure",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/deep-signal.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 5, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 5, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111106"),
                Title = "Block Forge",
                Description = "Sandbox criativo de construção modular em mundos procedurais.",
                Price = 59.90m,
                Category = "Sandbox",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/block-forge.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 6, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 6, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111107"),
                Title = "Shadow Arena",
                Description = "MOBA competitivo com heróis de classes assimétricas.",
                Price = 0.00m,
                Category = "MOBA",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/shadow-arena.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 7, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 7, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111108"),
                Title = "Crimson Protocol",
                Description = "FPS tático com foco em objetivos e comunicação em equipe.",
                Price = 119.99m,
                Category = "Shooter",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/crimson-protocol.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 8, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111109"),
                Title = "Echoes of Ruin",
                Description = "Metroidvania sombrio com progressão por habilidades.",
                Price = 94.49m,
                Category = "Action",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/echoes-of-ruin.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 9, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 9, 0, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111110"),
                Title = "Orbit Colony",
                Description = "Gerenciamento de colônia espacial com economia dinâmica.",
                Price = 139.00m,
                Category = "Management",
                ImageUrl = "https://cdn.trezzecloud.local/catalog/games/orbit-colony.jpg",
                DisponibilizationDate = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                CreatedAt = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc)
            });
    }
}
