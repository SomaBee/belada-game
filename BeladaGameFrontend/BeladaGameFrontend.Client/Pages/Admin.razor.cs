using System.Collections;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using ShardTypes;

namespace BeladaGameFrontend.Client.Pages;

public partial class Admin : ComponentBase
{
    protected override async Task OnInitializedAsync()
    {
        Players = await Http.GetFromJsonAsync<List<Player>>("/players");
    }

    private async Task StartNewGame()
    {
        var response = await Http.GetAsync("/startgame");
    }

    private List<Player>? Players { get; set; }

    private async Task TriggerBonusRunde()
    {
        await Http.GetAsync("/bonusrundenow"); 
    }
}