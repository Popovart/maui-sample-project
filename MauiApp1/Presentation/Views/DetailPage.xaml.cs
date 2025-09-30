using MauiApp1.Presentation.ViewModels;

namespace MauiApp1.Presentation.Views;

public partial class DetailPage : BaseContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
