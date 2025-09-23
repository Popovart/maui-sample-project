using System;
using MauiApp1.ViewModel;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;

namespace MauiApp1.Views;

public partial class MainPage : ContentPage
{
    

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    
}