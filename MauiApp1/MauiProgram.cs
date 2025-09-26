using Android.Renderscripts;
using CommunityToolkit.Maui;
using MauiApp1.Data.Local;
using MauiApp1.Popups;
using MauiApp1.Providers;
using MauiApp1.Services;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using MainViewModel = MauiApp1.ViewModels.MainViewModel;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit(options =>
			{
				options.SetPopupDefaults(
					new DefaultPopupSettings
					{
						Padding = 0,
						Margin = 0,
					}
				);
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont(
					"OpenSans-Regular.ttf",
					"OpenSansRegular"
				);
				fonts.AddFont(
					"OpenSans-Semibold.ttf",
					"OpenSansSemibold"
				);
			});
		builder.Services.AddTransient<ITaskProvider, TaskProvider>();
		builder.Services.AddTransient<ITaskService, TaskService>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddTransient<DetailPage>();
		builder.Services.AddTransient<DetailViewModel>();

		builder.Services.AddDbContext<LocalDbContext>();

		// builder.Services.AddTransientPopup<TaskPopup, TaskPopupViewModel>();
		builder.Services.AddTransientPopup<
			ComplexTaskPopup,
			TaskPopupViewModel
		>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

// .ConfigureMauiHandlers(h =>
// {
//     EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
//     {
// #if ANDROID
//         var native = handler.PlatformView;
//         native.Background = null;
//         native.SetPadding(0, native.PaddingTop, 0, native.PaddingBottom);
// #endif
//     });
// })
