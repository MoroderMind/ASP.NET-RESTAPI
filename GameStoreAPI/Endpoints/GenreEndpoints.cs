using System;
using GameStoreAPI.Data;
using GameStoreAPI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints (this WebApplication app)
    {
        var group = app.MapGroup("genres");

        // GET /genres
        group.MapGet("/", async (GameStoreContext dbContext) =>
        await dbContext.Genres
                       .Select(genre => genre.ToDto())   
                       .AsNoTracking()
                       .ToListAsync()
        );

        return group;
    }
}
