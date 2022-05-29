using Meowie.Lib;
using Meowie.Lib.Services;
using Meowie.Services;
using Radzen;

namespace Meowie;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif


#if DEBUG
        builder.Services.AddSingleton<IBackendUrlProvider>(new BackendUrlProvider("http://10.0.2.2:5000"));
#else
        builder.Services.AddSingleton<IBackendUrlProvider>(new BackendUrlProvider("https://meowieapi.azurewebsites.net");
#endif

        builder.Services.AddSingleton<ILocationService>(new LocationServiceApp());

        builder.Services.AddSingleton<StateContainerService>();
        builder.Services.AddScoped<AccelService>();
        builder.Services.AddScoped<OrientationService>();
        builder.Services.AddScoped<CompassService>();

        builder.Services.AddScoped<CatFactsClient>(sp =>
            new CatFactsClient(
                new HttpClient
                {
                    BaseAddress = new Uri(@"https://catfact.ninja")
                }));

        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();

        return builder.Build();
	}
}
