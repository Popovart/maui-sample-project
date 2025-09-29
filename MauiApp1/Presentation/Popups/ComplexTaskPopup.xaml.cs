using CommunityToolkit.Maui.Views;
using MauiApp1.Presentation.ViewModels;

namespace MauiApp1.Presentation.Popups;

public partial class ComplexTaskPopup : Popup
{
	public ComplexTaskPopup(TaskPopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
