using System.Globalization;
using MauiApp1.Domain.Services.NavigationService;
using MauiAPP1.Infrastructure.Local;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class App : Application
{
	private readonly INavigationService _navigationService;
	public App(INavigationService navigationService)
	{
		_navigationService = navigationService;
		InitializeComponent();
		//ru-RU
		// cs-CZ
		CultureInfo.CurrentUICulture = new CultureInfo("cs-CZ");
		
	}
	protected override Window CreateWindow(
		IActivationState? activationState
	)
	{
		return new Window(new AppShell(_navigationService));
	}
}
