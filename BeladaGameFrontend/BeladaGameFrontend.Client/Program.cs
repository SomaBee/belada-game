using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShardTypes;

namespace BeladaGameFrontend.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        
        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(BaseAddress.Address)
        });

        await builder.Build().RunAsync();
    }
}