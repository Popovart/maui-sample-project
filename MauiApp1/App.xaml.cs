using System.Globalization;
using MauiAPP1.Data.Local;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class App : Application
{
	public App(LocalDbContext dbContext)
	{
		InitializeComponent();
		//ru-RU
		// cs-CZ
		CultureInfo.CurrentUICulture = new CultureInfo("cs-CZ");
		
	}
	protected override Window CreateWindow(
		IActivationState? activationState
	)
	{
		return new Window(new AppShell());
	}
}
