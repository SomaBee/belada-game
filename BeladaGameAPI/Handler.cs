namespace BeladaGameAPI;

public class Handler
{
    GameStateService _gameStateService;

    public Handler(GameStateService gameStateService)
    {
        _gameStateService = gameStateService;
    }

    public void StartGame()
    {
        _gameStateService.StartGame();
    }
}