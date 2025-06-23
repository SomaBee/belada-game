using Microsoft.AspNetCore.SignalR;
using ShardTypes;

namespace BeladaGameAPI;

public class GameStateService
{
    private int _numberOfPlayers;
    private List<Player> _players = [];
    private List<Card> _deck = [];
    private readonly IHubContext<GameHub, IGameClient> _context;
    private readonly System.Timers.Timer _bonusRoundTimer;
    private Player _currentPlayer = null!;
    private Card? _currentCard;

    public GameStateService(IHubContext<GameHub, IGameClient> context)
    {
        _context = context;

        // Create a timer with a random interval between 2 and 5 minutes.
        _bonusRoundTimer = new System.Timers.Timer(6*60*1000);

        // Hook up the Elapsed event for the timer. 
        _bonusRoundTimer.Elapsed += async (_, _) => await BonusRound();
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
        _players = new List<Player>();
        _deck = GenerateDeck();
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

        var shuffledDeck = deck.OrderBy(_ => Guid.NewGuid()).ToList();

        return shuffledDeck;
    }

    public List<Player> GetPlayers()
    {
        return _players;
    }

    public async Task AddPlayer(string? name)
    {
        if (_players.Any(x => x.Name == name))
        {
            return;
        }

        _players.Add(new Player { Name = name });
        _numberOfPlayers++;
        await _context.Clients.All.PlayerAdded(name);

        if (_numberOfPlayers == 1)
        {
            await _context.Clients.All.NextPlayer(name);
            _currentPlayer = _players.First();
        }
        else
        {
            await _context.Clients.All.NextPlayer(_currentPlayer.Name);
        }
    }

    public async Task RemovePlayer(string name)
    {
        _players.Remove(_players.First(x => x.Name == name));
        _numberOfPlayers--;
        await _context.Clients.All.PlayerRemoved(name);

        if (_currentPlayer.Name == name)
        {
            await _context.Clients.All.NextPlayer(_players.First().Name);
            _currentPlayer = _players.First();
        }
    }

    public async Task DrawCard(string name)
    {
        if (_deck.Count == 0)
        {
            await _context.Clients.All.GameOver();
            _currentCard = null;
            StartGame();

            return;
        }

        var player = _players.First(x => x.Name == name);
        var card = _deck.First();

        if (card.Type is CardType.Effect or CardType.Trap)
        {
            player.Hand.Add(card);
        }

        _deck.Remove(card);
        _currentCard = card;
        await _context.Clients.All.CardDrawn(card);
    }

    public async Task TurnFinished(string currentPlayerName)
    {
        _currentPlayer = _players.IndexOf(_players.First(x => x.Name == currentPlayerName)) == _players.Count - 1
            ? _players.First()
            : _players[_players.IndexOf(_players.First(x => x.Name == currentPlayerName)) + 1];

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
        var player = _players.First(x => x.Name == playerName);
        var card = player.Hand.First(x => x.Name == cardName);
        player.Hand.Remove(card);
        await _context.Clients.All.CardPlayed(new Tuple<Player, Card>(player, card));
    }

    public Player GetPlayerState(string name)
    {
        return _players.First(x => x.Name == name);
    }

    public async Task PlayerDrank(string name)
    {
        var player = _players.First(x => x.Name == name);
        player.NumberOfDrinksDone++;
        await _context.Clients.All.PlayerDrank(player);
    }

    public async Task BonusRunde()
    {
        await _context.Clients.All.BonusRunde();
    }
}