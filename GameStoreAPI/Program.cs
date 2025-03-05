using GameStoreAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Everything below is our configuration 
// It sets up what happens with HTTPs requests, e.g. how to handle them

var app = builder.Build();

// Calling our Endpoints file, that we created with all the functionality
app.MapGameEndpoints();

app.Run();
