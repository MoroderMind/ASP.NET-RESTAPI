using System;
using GameStoreAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}
