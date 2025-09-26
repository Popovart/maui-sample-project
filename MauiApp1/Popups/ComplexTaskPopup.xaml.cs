using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using MauiApp1.ViewModels;

namespace MauiApp1.Popups;

public partial class ComplexTaskPopup : Popup
{
	public ComplexTaskPopup(TaskPopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
