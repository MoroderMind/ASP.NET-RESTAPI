using GameStoreAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Everything below is our configuration 
// It sets up what happens with HTTPs requests, e.g. how to handle them

var app = builder.Build();

const string GetGameEndPointName = "GetGame";

List<GameDTO> games = [
    new (1,"Street Fighter II", "Fighting", 19.99M, new DateOnly(1992,7,15)),
    new (2,"Final Fantasy XIV", "Roleplaying", 59.99M, new DateOnly (2010,9,30)),
    new (3,"FIFA 23", "Sports", 69.99M, new DateOnly(2022, 9, 27))
];

//  GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(GetGameEndPointName);

// POST /games
app.MapPost("games", (CreateGameDTO newGame) =>
{
    GameDTO game = new GameDTO(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.price,
        newGame.ReleaseDate);
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
});

// PUT /games
app.MapPut("games/{id}", (int id, UpdateGameDTO updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    games[index] = new GameDTO(
        id, 
        updatedGame.Name, 
        updatedGame.Genre, 
        updatedGame.price, 
        updatedGame.ReleaseDate);
    
    return Results.NoContent();
});


app.Run();
