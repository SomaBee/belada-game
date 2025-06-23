using Microsoft.AspNetCore.SignalR;
using ShardTypes;

namespace BeladaGameAPI;

public class GameHub : Hub<IGameClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId)
            .ReciveNotification($"Welcome to Belada Game! {Context.User?.Identity?.Name}");
        await base.OnConnectedAsync();
    }
}

public interface IGameClient
{
    Task ReciveNotification(string message);

    Task PlayerAdded(string? name);
    
    Task PlayerRemoved(string name);
    
    Task CardDrawn(Card? card);
    
    Task NextPlayer(string? name);

    Task GameOver();

    Task CurrentPlayerEffects(List<Card> toList);

    Task CardPlayed(Tuple<Player, Card> tuple);
    
    Task BonusRunde();
    
    Task PlayerDrank(Player player);
}