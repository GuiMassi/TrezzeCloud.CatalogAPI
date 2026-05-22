using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrezzeCloud.Catalog.Application.DTOs;
using TrezzeCloud.Catalog.Domain.Entities;
using TrezzeCloud.Catalog.Infrastructure.Data;

namespace TrezzeCloud.Catalog.Api.Controllers;

[ApiController]
[Route("api/games")]
public sealed class GameController : ControllerBase
{
    private readonly CatalogDbContext _context;

    public GameController(CatalogDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var games = await _context.Games
            .Where(x => x.IsActive)
            .Select(x => new GameResponse(
                x.Id,
                x.Title,
                x.Description,
                x.Price,
                x.Category,
                x.ImageUrl,
                x.DisponibilizationDate,
                x.IsAvailable()))
            .ToListAsync();

        return Ok(games);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(x => x.Id == id);

        if (game is null)
            return NotFound();

        return Ok(new GameResponse(
            game.Id,
            game.Title,
            game.Description,
            game.Price,
            game.Category,
            game.ImageUrl,
            game.DisponibilizationDate,
            game.IsAvailable()));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateGameRequest request)
    {
        var game = new Game(
            request.Title,
            request.Description,
            request.Price,
            request.Category,
            request.ImageUrl,
            request.DisponibilizationDate);

        await _context.Games.AddAsync(game);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = game.Id },
            new GameResponse(
                game.Id,
                game.Title,
                game.Description,
                game.Price,
                game.Category,
                game.ImageUrl,
                game.DisponibilizationDate,
                game.IsAvailable()));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateGameRequest request)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(x => x.Id == id);

        if (game is null)
            return NotFound();

        game.Update(
            request.Title,
            request.Description,
            request.Price,
            request.Category,
            request.ImageUrl,
            request.DisponibilizationDate);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(x => x.Id == id);

        if (game is null)
            return NotFound();

        game.Disable();

        await _context.SaveChangesAsync();

        return NoContent();
    }
}