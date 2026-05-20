using Microsoft.EntityFrameworkCore;
using TrezzeCloud.Catalog.Domain.Entities;

namespace TrezzeCloud.Catalog.Infrastructure.Data;

public sealed class CatalogDbContext : DbContext
{
    public CatalogDbContext(
        DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<UserLibrary> UserLibraries => Set<UserLibrary>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            entity.Property(x => x.Price)
                .HasPrecision(18, 2);

            entity.Property(x => x.Category)
                .HasMaxLength(100);

            entity.Property(x => x.ImageUrl)
                .HasMaxLength(500);
        });

        modelBuilder.Entity<UserLibrary>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasIndex(x => new
            {
                x.UserId,
                x.GameId
            }).IsUnique();
        });

        base.OnModelCreating(modelBuilder);
    }
}