using System;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using MauiApp1.Popups;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;
using MainViewModel = MauiApp1.ViewModels.MainViewModel;

namespace MauiApp1.Views;

public partial class MainPage : ContentPage
{
    

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


    
}