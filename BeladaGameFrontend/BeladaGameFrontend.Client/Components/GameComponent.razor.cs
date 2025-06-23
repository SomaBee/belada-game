using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using ShardTypes;

namespace BeladaGameFrontend.Client.Components;

public partial class GameComponent
{
    [Parameter]
    public Player? Player { get; set; }

    private HubConnection HubConnection { get; set; } = null!;

    private readonly List<Card> _myHand = new();
    
    private Card? _currentCard;

    private Player? _currentPlayer;
    
    private bool _myTurn;
    private bool _hasDrawn;
    private bool _gameOver;
    private bool _bonusrunde;
    private List<Card> _currentPlayerEffects = new();

    protected override async Task OnInitializedAsync()
    {
        HubConnection = new HubConnectionBuilder()
            .WithUrl($"{BaseAddress.Address}/gamehub")
            .Build();
        
        HubConnection.On<string>("PlayerAdded", async name => { await PlayerAdded(name); });
        
        HubConnection.On<string>("PlayerRemoved", async _ => { await PlayerRemoved(); });
        
        HubConnection.On("GameOver", () => _gameOver = true);
        
        HubConnection.On("BonusRunde", async () =>
        {
            await BonusRunde();
        });
        
        HubConnection.On<Card?>("CardDrawn", async currentCard => { await CardDrawn(currentCard); });
        
        HubConnection.On<List<Card>>("CurrentPlayerEffects", async cards => { await UpdatePlayersEffects(cards); });
        
        HubConnection.On<string>("NextPlayer", async name => { await NextPlayer(name); });
        
        HubConnection.On<Tuple<Player,Card>>("CardPlayed", async _ =>
        {
            await CardPlayed();
        });
        HubConnection.On<Player>("PlayerDrank", async _ =>
        {
            await UpdatePlayerDrinks();
        });
        
        Players = await Http.GetFromJsonAsync<List<Player>>("/players");
        
        await HubConnection.StartAsync();

        await Http.PostAsync("/enteredgame", null);
        
        await base.OnInitializedAsync();
    }

    private async Task UpdatePlayerDrinks()
    {
        if (Player?.Name == _currentPlayer?.Name)
        {
            Players = await Http.GetFromJsonAsync<List<Player>>("/players");

            if (Players != null)
            {
                _currentPlayer = Players.FirstOrDefault(x => x.Name == _currentPlayer?.Name);
            }
        }

        await InvokeAsync(StateHasChanged);
    }

    private Task PlayerRemoved()
    {
        throw new NotImplementedException();
    }

    private async Task UpdatePlayersEffects(List<Card> cards)
    {
        _currentPlayerEffects = cards;
        await InvokeAsync(StateHasChanged);
    }

    private Task CardPlayed()
    {
        return Task.CompletedTask;
    }

    private async Task PlayerAdded(string name)
    {
        Players = await Http.GetFromJsonAsync<List<Player>>("/players");
        if(name == Player?.Name)
        {
           Player = await Http.GetFromJsonAsync<Player>($"mystate/{name}");
        }
        await InvokeAsync(StateHasChanged);
    }

    private async Task CardDrawn(Card? currentCard)
    {
        _currentCard = currentCard;

        if (_myTurn)
        {
            if(currentCard is { Type: CardType.Effect })
            {
                _myHand.Add(currentCard);
            }

            if (currentCard is { Type: CardType.Trap })
            {
                if (_currentCard != null) _myHand.Add(_currentCard);
            }
        }

        await InvokeAsync(StateHasChanged);
    }

    private async Task BonusRunde()
    {
        _bonusrunde = true;
        await InvokeAsync(StateHasChanged);
        await Task.Delay(TimeSpan.FromSeconds(10));
        _bonusrunde = false;
        await InvokeAsync(StateHasChanged);
    }

    private List<Player>? Players { get; set; }

    private async Task NextPlayer(string name)
    {
        _currentPlayer = (await Http.GetFromJsonAsync<List<Player>>("/players") ?? []).FirstOrDefault(x=>x.Name == name);
        _myTurn = _currentPlayer?.Name == Player?.Name;

        if (_myTurn)
        {
            foreach (var card in _myHand)
            {
                if (card.Type == CardType.Effect)
                {
                    card.Duration--;
                }
                
            }
            _myHand.RemoveAll(x=> x is { Duration: <= 0, Type: CardType.Effect });
        }
        
        await InvokeAsync(StateHasChanged);
    }

    private string GetImagePath()
    {
        return $"images/{_currentCard?.ImageName ?? "default.png"}";
    }

    private async Task DrawCard()
    {
        await Http.PostAsync("/drawcard", new StringContent($"\"{Player?.Name}\"", Encoding.UTF8, "application/json"));
        await InvokeAsync(StateHasChanged);
        _hasDrawn = true;
    }

    private async Task FinishTurn()
    {
        await Http.PostAsync("/turnfinished", new StringContent($"\"{Player?.Name}\"", Encoding.UTF8, "application/json")); 
        _hasDrawn = false;
    }

    private int GetPlayerNumber()
    {
        return Players?.Count ?? 0;
    }

    private async Task PlayCard(Card card)
    {
        var playCardData = new PlayCardData
        {
            PlayerName = Player?.Name,
            CardName = card.Name,
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(playCardData), Encoding.UTF8, "application/json");
        _myHand.Remove(card);

        await Http.PostAsync("/playcard", jsonContent);
    }

    private void PlayerDrank()
    {
        Http.GetAsync($"/takedrink/{Player?.Name}");
    }
}