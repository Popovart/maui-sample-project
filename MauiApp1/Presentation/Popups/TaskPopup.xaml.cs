using MauiApp1.Presentation.ViewModels;

namespace MauiApp1.Presentation.Popups;

public partial class TaskPopup : ContentView
{
	public TaskPopup(TaskPopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
