﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using Meowie.Data;
using Meowie.Lib.Services;
using Meowie.Services;

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

		builder.Services.AddSingleton<WeatherForecastService>();

        builder.Services.AddSingleton<ILocationService>(new LocationServiceApp());

        builder.Services.AddSingleton<StateContainerService>();
        builder.Services.AddSingleton<AccelService>();
        builder.Services.AddSingleton<CompassService>();

        builder.Services.AddScoped<CatFactsClient>(sp =>
            new CatFactsClient(
                new HttpClient
                {
                    BaseAddress = new Uri(@"https://catfact.ninja")
                }));

        return builder.Build();
	}
}
