using System;
using GameStoreAPI.DTOs;
using GameStoreAPI.Entities;

namespace GameStoreAPI.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDTO game)
    {
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static GameDTO ToDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }

}
