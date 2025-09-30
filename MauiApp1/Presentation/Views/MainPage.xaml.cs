using MainViewModel = MauiApp1.Presentation.ViewModels.MainViewModel;

namespace MauiApp1.Presentation.Views;

public partial class MainPage : BaseContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
	
	// protected override async void OnAppearing()
	// {
	// 	base.OnAppearing();
	// 	if (BindingContext is MainViewModel vm)
	// 		await vm.RefreshCommand.ExecuteAsync(null);
	// }
}
