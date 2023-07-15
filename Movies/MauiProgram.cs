﻿using Microsoft.Extensions.Logging;
using Movies.Controls;
#if IOS
using Movies.Platforms.iOS.Handlers;
#endif
#if ANDROID
using Movies.Platforms.Android.Handlers;
#endif

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
#if ANDROID
				handlers.AddHandler<RatingView, RatingViewHandlerAndroid>();
#endif

#if IOS
				handlers.AddHandler<RatingView, RatingViewHandleriOS>();
#endif
            }); ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
