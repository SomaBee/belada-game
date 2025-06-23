using BeladaGameAPI;
using Microsoft.AspNetCore.Mvc;
using ShardTypes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddSingleton<GameStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
app.MapHub<GameHub>("/gamehub");


app.MapGet("/startgame", (GameStateService gameStateService) =>
{
    gameStateService.StartGame();
    return Results.Ok();
});

app.MapGet("players", (GameStateService gameStateService) => TypedResults.Ok(gameStateService.GetPlayers()));
app.MapPost("/addplayer", async (GameStateService gameStateService, [FromBody]string? name) =>
{
    await gameStateService.AddPlayer(name);
    return Results.Ok();
});
app.MapPost("/removeplayer", async (GameStateService gameStateService, [FromBody]string name) =>
{
    await gameStateService.RemovePlayer(name);
    return Results.Ok();
});

app.MapPost("/drawcard", async (GameStateService gameStateService, [FromBody]string name) =>
{
    await gameStateService.DrawCard(name);
    return Results.Ok();
});

app.MapPost("/turnfinished", async (GameStateService gameStateService, [FromBody]string name) =>
{
    await gameStateService.TurnFinished(name);
    return Results.Ok();
});

app.MapPost("/enteredgame", async (GameStateService gameStateService) =>
{
    await gameStateService.EnteredGame();
    return Results.Ok();
});

app.MapPost("/playcard", async (GameStateService gameStateService, [FromBody] PlayCardData playCardData) =>
{
    await gameStateService.PlayCard(playCardData.PlayerName, playCardData.CardName);
    return Results.Ok();
});

app.MapGet("/mystate/{name}", (GameStateService gameStateService, string name) => Task.FromResult(TypedResults.Ok(gameStateService.GetPlayerState(name))));
app.MapGet("takedrink/{name}", async (GameStateService gameStateService, string name) =>
{
    await gameStateService.PlayerDrank(name);
    return Results.Ok();
});

app.MapGet("/bonusrundenow", async (GameStateService gameStateService) =>
{
    await gameStateService.BonusRunde();
    return Results.Ok();
});


app.Run();

