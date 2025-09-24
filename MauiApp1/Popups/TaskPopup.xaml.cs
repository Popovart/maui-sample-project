using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.ViewModels;

namespace MauiApp1.Popups;

public partial class TaskPopup : ContentView
{
    public TaskPopup(TaskPopupViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}