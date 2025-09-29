using Android.Renderscripts;
using CommunityToolkit.Maui;
using MauiAPP1.Data.Local;
using MauiApp1.Popups;
using MauiApp1.Providers;
using MauiApp1.Services;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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

		builder.Services.AddDbContext<LocalDbContext>(
			options =>
			{
#if ANDROID
				var dbPath = Android.App.Application.Context.GetDatabasePath("LocalDb.db")?.Path ?? Path.Combine(FileSystem.AppDataDirectory, "LocalDb.db");
#else 
				var dbPath = Path.Combine(FileSystem.AppDataDirectory, "LocalDb.db");
#endif				
				Directory.CreateDirectory(Path.GetDirectoryName(dbPath) ?? throw new InvalidOperationException("No directory in path"));
				options.UseSqlite($"Data Source={dbPath}");
				
				// For more configurations:
				// var cs = new SqliteConnectionStringBuilder
				// {
				//     DataSource = dbPath,
				//     Mode = SqliteOpenMode.ReadWriteCreate
				// }.ToString();
				// options.UseSqlite(cs);
			}
		);

		

		// builder.Services.AddTransientPopup<TaskPopup, TaskPopupViewModel>();
		builder.Services.AddTransientPopup<
			ComplexTaskPopup,
			TaskPopupViewModel
		>();


#if DEBUG
		builder.Logging.AddDebug();
#endif
		
		var app = builder.Build();
		
		Task.Run(async () =>
		{
			using var scope = app.Services.CreateScope();
			var db = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
			await db.Database.MigrateAsync();
		});
		
		
		return app;
	}
}