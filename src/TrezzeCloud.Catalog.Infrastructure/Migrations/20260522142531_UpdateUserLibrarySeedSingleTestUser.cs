using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrezzeCloud.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserLibrarySeedSingleTestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "ImageUrl", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111101"), "RPG", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "RPG de aventura em ilhas flutuantes com foco em exploração.", "https://cdn.trezzecloud.local/catalog/games/skyward-legends.jpg", true, 129.90m, "Skyward Legends" },
                    { new Guid("11111111-1111-1111-1111-111111111102"), "Racing", new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Corridas urbanas de alta velocidade com trilha eletrônica intensa.", "https://cdn.trezzecloud.local/catalog/games/neon-sprint.jpg", true, 89.90m, "Neon Sprint" },
                    { new Guid("11111111-1111-1111-1111-111111111103"), "Strategy", new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Estratégia tática por turnos com batalhas em larga escala.", "https://cdn.trezzecloud.local/catalog/games/iron-tactics.jpg", true, 99.50m, "Iron Tactics" },
                    { new Guid("11111111-1111-1111-1111-111111111104"), "Simulation", new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Simulação de fazenda mágica com crafting e missões cooperativas.", "https://cdn.trezzecloud.local/catalog/games/mystic-valley.jpg", true, 74.00m, "Mystic Valley" },
                    { new Guid("11111111-1111-1111-1111-111111111105"), "Adventure", new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Thriller sci-fi com investigação em uma estação submersa.", "https://cdn.trezzecloud.local/catalog/games/deep-signal.jpg", true, 109.00m, "Deep Signal" },
                    { new Guid("11111111-1111-1111-1111-111111111106"), "Sandbox", new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Sandbox criativo de construção modular em mundos procedurais.", "https://cdn.trezzecloud.local/catalog/games/block-forge.jpg", true, 59.90m, "Block Forge" },
                    { new Guid("11111111-1111-1111-1111-111111111107"), "MOBA", new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "MOBA competitivo com heróis de classes assimétricas.", "https://cdn.trezzecloud.local/catalog/games/shadow-arena.jpg", true, 0.00m, "Shadow Arena" },
                    { new Guid("11111111-1111-1111-1111-111111111108"), "Shooter", new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "FPS tático com foco em objetivos e comunicação em equipe.", "https://cdn.trezzecloud.local/catalog/games/crimson-protocol.jpg", true, 119.99m, "Crimson Protocol" },
                    { new Guid("11111111-1111-1111-1111-111111111109"), "Action", new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Metroidvania sombrio com progressão por habilidades.", "https://cdn.trezzecloud.local/catalog/games/echoes-of-ruin.jpg", true, 94.49m, "Echoes of Ruin" },
                    { new Guid("11111111-1111-1111-1111-111111111110"), "Management", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Gerenciamento de colônia espacial com economia dinâmica.", "https://cdn.trezzecloud.local/catalog/games/orbit-colony.jpg", true, 139.00m, "Orbit Colony" }
                });

            migrationBuilder.InsertData(
                table: "UserLibraries",
                columns: new[] { "Id", "GameId", "PurchasedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222201"), new Guid("11111111-1111-1111-1111-111111111101"), new DateTime(2026, 2, 1, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("22222222-2222-2222-2222-222222222202"), new Guid("11111111-1111-1111-1111-111111111102"), new DateTime(2026, 2, 2, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("22222222-2222-2222-2222-222222222203"), new Guid("11111111-1111-1111-1111-111111111103"), new DateTime(2026, 2, 3, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("22222222-2222-2222-2222-222222222204"), new Guid("11111111-1111-1111-1111-111111111104"), new DateTime(2026, 2, 4, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("22222222-2222-2222-2222-222222222205"), new Guid("11111111-1111-1111-1111-111111111105"), new DateTime(2026, 2, 5, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111101"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111104"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111105"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111106"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111107"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111108"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111109"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111110"));

            migrationBuilder.DeleteData(
                table: "UserLibraries",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.DeleteData(
                table: "UserLibraries",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.DeleteData(
                table: "UserLibraries",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.DeleteData(
                table: "UserLibraries",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222204"));

            migrationBuilder.DeleteData(
                table: "UserLibraries",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222205"));
        }
    }
}
