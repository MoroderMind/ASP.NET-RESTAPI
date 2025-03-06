using GameStoreAPI.Data;
using GameStoreAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);

// Everything below is our configuration 
// It sets up what happens with HTTPs requests, e.g. how to handle them

var app = builder.Build();

// Calling our Endpoints file, that we created with all the functionality
app.MapGameEndpoints();

// custom method that can be used to migrate the db
app.MigrateDb();

app.Run();
