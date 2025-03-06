using System;
using GameStoreAPI.Data;
using GameStoreAPI.DTOs;
using GameStoreAPI.Entities;
using GameStoreAPI.Mapping;

namespace GameStoreAPI.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

    private static readonly List<GameSummaryDTO> games = [
        new (1,"Street Fighter II", "Fighting", 19.99M, new DateOnly(1992,7,15)),
        new (2,"Final Fantasy XIV", "Roleplaying", 59.99M, new DateOnly (2010,9,30)),
        new (3,"FIFA 23", "Sports", 69.99M, new DateOnly(2022, 9, 27))
    ];

    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {
        // Using group, so we dont need to repeat ourselves with the endpoint /games
            // Known as a route group builder
        var group = app.MapGroup("games").WithParameterValidation();
        //  GET /games
        group.MapGet("/", () => games);

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
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
        
        // Lastly return the app!
        return group;
    }
}
