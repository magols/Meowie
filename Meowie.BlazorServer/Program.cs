using Meowie.Lib;
using Meowie.Lib.Services;
using Meowie.Lib.Web;
using Radzen;

namespace Meowie.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddScoped<ILocationService, GeoService>();
            builder.Services.AddSingleton<StateContainerService>();

            builder.Services.AddSingleton<IBackendUrlProvider>(new BackendUrlProvider(builder.Configuration["MEOWIE_API_URL"] ?? "https://localhost:5001"));

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<CatFactsClient>(sp =>
                new CatFactsClient(
                    new HttpClient
                    {
                        BaseAddress = new Uri(@"https://catfact.ninja")
                    }));

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}