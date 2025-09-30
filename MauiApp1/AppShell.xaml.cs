using MauiApp1.Domain.Services.NavigationService;
using MauiApp1.Presentation.Views;
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class AppShell : Shell
{
	private readonly INavigationService _navigationService;
	public AppShell(INavigationService navigationService)
	{
		_navigationService = navigationService;
		
		InitRouting();
		InitializeComponent();
	}

	protected override async void OnHandlerChanged()
	{
		base.OnHandlerChanged();

		if (Handler != null)
		{
			await _navigationService.InitializeAsync();
		}
	}

	private static void InitRouting()
	{
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
	}
}
