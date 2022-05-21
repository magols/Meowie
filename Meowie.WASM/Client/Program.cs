using Meowie.Data;
using Meowie.Lib.Services;
using Meowie.Lib.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Meowie.WASM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<ILocationService, GeoService>();
            builder.Services.AddSingleton<StateContainerService>();

            builder.Services.AddScoped<CatFactsClient>(sp =>
                new CatFactsClient(
                    new HttpClient
                {
                    BaseAddress = new Uri(@"https://catfact.ninja")
                }));

            await builder.Build().RunAsync();
        }
    }
}