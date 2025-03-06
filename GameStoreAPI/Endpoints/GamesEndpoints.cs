using System;
using GameStoreAPI.Data;
using GameStoreAPI.DTOs;
using GameStoreAPI.Entities;
using GameStoreAPI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";
    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {
        // Using group, so we dont need to repeat ourselves with the endpoint /games
            // Known as a route group builder
        var group = app.MapGroup("games").WithParameterValidation();

        //  GET /games
        group.MapGet("/", (GameStoreContext dbcontext) => 
            dbcontext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToGameSummaryDto())
                .AsNoTracking());

        // GET /games/1
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());

        }).WithName(GetGameEndPointName);

        // POST /games
        group.MapPost("/", (CreateGameDTO newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game.ToGameDetailsDto());
        });

        // PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDTO updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = dbContext.Games.Find(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
            dbContext.SaveChanges();
            return Results.NoContent();
        });


        // DELETE /game/1
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
        {
            dbContext.Games
                     .Where(game => game.Id == id)
                     .ExecuteDelete();
    
            return Results.NoContent();
        });
        
        // Lastly return the app!
        return group;
    }
}
