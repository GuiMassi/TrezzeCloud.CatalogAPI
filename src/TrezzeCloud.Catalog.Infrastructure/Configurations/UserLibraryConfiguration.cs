using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrezzeCloud.Catalog.Domain.Entities;

namespace TrezzeCloud.Catalog.Infrastructure.Configurations;

public sealed class UserLibraryConfiguration : IEntityTypeConfiguration<UserLibrary>
{
    public void Configure(EntityTypeBuilder<UserLibrary> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new
        {
            x.UserId,
            x.GameId
        }).IsUnique();

        builder.Property(x => x.PurchasedAt)
            .IsRequired();

        builder.HasData(
            new
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                GameId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                PurchasedAt = new DateTime(2026, 2, 1, 12, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                GameId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                PurchasedAt = new DateTime(2026, 2, 2, 12, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                GameId = Guid.Parse("11111111-1111-1111-1111-111111111103"),
                PurchasedAt = new DateTime(2026, 2, 3, 12, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222204"),
                UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                GameId = Guid.Parse("11111111-1111-1111-1111-111111111104"),
                PurchasedAt = new DateTime(2026, 2, 4, 12, 0, 0, DateTimeKind.Utc)
            },
            new
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222205"),
                UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                GameId = Guid.Parse("11111111-1111-1111-1111-111111111105"),
                PurchasedAt = new DateTime(2026, 2, 5, 12, 0, 0, DateTimeKind.Utc)
            });
    }
}
