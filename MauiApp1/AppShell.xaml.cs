using MauiApp1.Views;
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
	}
}
