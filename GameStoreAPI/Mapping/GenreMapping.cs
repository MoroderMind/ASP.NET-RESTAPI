using System;
using GameStoreAPI.Entities;

namespace GameStoreAPI.Mapping;

public static class GenreMapping
{
    public static GenreDTO ToDto(this Genre genre)
    {
        return new GenreDTO (genre.Id, genre.Name);
    }
}
