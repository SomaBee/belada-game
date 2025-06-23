using Microsoft.AspNetCore.SignalR;
using ShardTypes;

namespace BeladaGameAPI;

public class GameStateService
{
    private int _numberOfPlayers = 0;
    private List<Player> players = new List<Player>();
    private List<Card> Deck = new List<Card>();
    private readonly IHubContext<GameHub, IGameClient> _context;
    private System.Timers.Timer _bonusRoundTimer;
    private readonly Random _random;
    private Player _currentPlayer = null!;
    private Card? _currentCard = null!;

    public GameStateService(IHubContext<GameHub, IGameClient> context)
    {
        _context = context;

        _random = new Random();

        // Create a timer with a random interval between 2 and 5 minutes.
        _bonusRoundTimer = new System.Timers.Timer(6*60*1000);

        // Hook up the Elapsed event for the timer. 
        _bonusRoundTimer.Elapsed += async (sender, e) => await BonusRound();
        _bonusRoundTimer.AutoReset = true;
        _bonusRoundTimer.Enabled = true;

        StartGame();
    }

    private async Task BonusRound()
    {
        await _context.Clients.All.BonusRunde();
    }

    public void StartGame()
    {
        _currentCard = null!;
        _numberOfPlayers = 0;
        _currentPlayer = null!;
        players = new List<Player>();
        Deck = GenerateDeck();
    }

    private List<Card> GenerateDeck()
    {
        var deck = Cards.AvailableCards;

        // Duplicate some cards randomly in the deck
        var random = new Random();

        for (var i = 0; i < 10; i++)
        {
            var card = deck[random.Next(deck.Count)];
            deck.Add(card);
        }

        var shuffledDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

        return shuffledDeck;
    }

    public List<Player> GetPlayers()
    {
        return players;
    }

    public async Task AddPlayer(string? name)
    {
        if (players.Any(x => x.Name == name))
        {
            return;
        }

        players.Add(new Player { Name = name });
        _numberOfPlayers++;
        await _context.Clients.All.PlayerAdded(name);

        if (_numberOfPlayers == 1)
        {
            await _context.Clients.All.NextPlayer(name);
            _currentPlayer = players.First();
        }
        else
        {
            await _context.Clients.All.NextPlayer(_currentPlayer.Name);
        }
    }

    public async Task RemovePlayer(string name)
    {
        players.Remove(players.First(x => x.Name == name));
        _numberOfPlayers--;
        await _context.Clients.All.PlayerRemoved(name);

        if (_currentPlayer.Name == name)
        {
            await _context.Clients.All.NextPlayer(players.First().Name);
            _currentPlayer = players.First();
        }
    }

    public async Task DrawCard(string name)
    {
        if (Deck.Count == 0)
        {
            await _context.Clients.All.GameOver();
            _currentCard = null;
            StartGame();

            return;
        }

        var player = players.First(x => x.Name == name);
        var card = Deck.First();

        if (card.Type is CardType.Effect or CardType.Trap)
        {
            player.Hand.Add(card);
        }

        Deck.Remove(card);
        _currentCard = card;
        await _context.Clients.All.CardDrawn(card);
    }

    public async Task TurnFinished(string currentPlayerName)
    {
        _currentPlayer = players.IndexOf(players.First(x => x.Name == currentPlayerName)) == players.Count - 1
            ? players.First()
            : players[players.IndexOf(players.First(x => x.Name == currentPlayerName)) + 1];

        foreach (var handCard in _currentPlayer.Hand)
        {
            if (handCard.Type == CardType.Effect)
            {
                handCard.Duration--;
            }
        }

        _currentPlayer.Hand.RemoveAll(x => x.Duration <= 0 && x.Type == CardType.Effect);
        
        await _context.Clients.All.NextPlayer(_currentPlayer.Name);

        await _context.Clients.All.CurrentPlayerEffects(_currentPlayer.Hand.Where(x => x.Type == CardType.Effect)
            .ToList());
    }

    public async Task EnteredGame()
    {
        await _context.Clients.All.NextPlayer(_currentPlayer.Name);
        await _context.Clients.All.CardDrawn(_currentCard);
    }

    public async Task PlayCard(string? playerName, string cardName)
    {
        var player = players.First(x => x.Name == playerName);
        var card = player.Hand.First(x => x.Name == cardName);
        player.Hand.Remove(card);
        await _context.Clients.All.CardPlayed(new Tuple<Player, Card>(player, card));
    }

    public Player GetPlayerState(string name)
    {
        return players.First(x => x.Name == name);
    }

    public async Task PlayerDrank(string name)
    {
        var player = players.First(x => x.Name == name);
        player.NumberOfDrinksDone++;
        await _context.Clients.All.PlayerDrank(player);
    }

    public async Task BonusRunde()
    {
        await _context.Clients.All.BonusRunde();
    }
}