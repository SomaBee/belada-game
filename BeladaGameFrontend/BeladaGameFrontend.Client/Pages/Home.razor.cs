using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;
using ShardTypes;

namespace BeladaGameFrontend.Client.Pages;

public partial class Home
{
   private HubConnection? _hubConnection;
   private readonly List<string> _messages = new();
   private bool _loading = true;
   private bool _ingame = false;
   
   Player player = new Player();

   public List<Player>? Players { get; set; } = new();

   public string Name { get; set; } = "";

   protected override async Task OnInitializedAsync()
   {
      _hubConnection = new HubConnectionBuilder()
         .WithUrl($"{BaseAddress.Address}/gamehub")
         .Build();
      
      _hubConnection.On<string>("ReciveNotification", message =>
      {
         _messages.Add(message);
         InvokeAsync(StateHasChanged);
      });
      _hubConnection.On<string>("PlayerAdded", async name =>
      {
         Players = await Http.GetFromJsonAsync<List<Player>>("/players");
         await InvokeAsync(StateHasChanged);
      });
      _hubConnection.On<string>("PlayerRemoved", async name =>
      {
         Players = await Http.GetFromJsonAsync<List<Player>>("/players");
         await InvokeAsync(StateHasChanged);
      });

      await _hubConnection.StartAsync();
      
      Players = await Http.GetFromJsonAsync<List<Player>>("/players");
      _loading = false;
   }

   public async ValueTask DisposeAsync()
   {
      if (_hubConnection is not null)
      {
         await _hubConnection.DisposeAsync();
      }
   }

   private async Task EnterGame()
   {
      var response = await Http.PostAsync("/addplayer", new StringContent($"\"{Name}\"", Encoding.UTF8, "application/json"));
      Players = await Http.GetFromJsonAsync<List<Player>>("/players");
      player = Players?.FirstOrDefault(x => x.Name == Name) ?? new Player(); 
      _ingame = true;
   }

   private async Task LeaveGame()
   {
      if (player.Name != "")
      {
         await Http.PostAsync("/removeplayer", new StringContent($"\"{player.Name}\"", Encoding.UTF8, "application/json"));
      }
      _ingame = false;
   }

   private void SetPlayer(string? playerName)
   {
      player = Players?.FirstOrDefault(x => x.Name == playerName) ?? new Player();
      _ingame = true;
   }
}