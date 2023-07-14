﻿using Microsoft.Extensions.Logging;
using Movies.Controls;
using Movies.Handlers;

namespace Movies;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler<RatingView, RatingViewHandlerAndroid>();
            }); ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
