var builder = WebApplication.CreateBuilder(args);

// Everything below is our configuration 
// It sets up what happens with HTTPs requests, e.g. how to handle them
// I
var app = builder.Build();

// Means that if we get any Get request, we will just reply with hello world
app.MapGet("/", () => "Hello World!");

app.Run();
