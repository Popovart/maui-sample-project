using System.Collections.ObjectModel;
using System.ComponentModel;
using Android.Database;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Views;

namespace MauiApp1.ViewModel;

public partial class MainViewModel : ObservableObject
{

    [ObservableProperty]
    ObservableCollection<TaskModel> items = new();
    
    [ObservableProperty]
    string text;

    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(Text)) return;
        Items.Add(new TaskModel(
            Guid.NewGuid(), 
            Text, 
            null,
            DateTime.UtcNow.ToString("u")));
        Text = string.Empty;
    }

    [RelayCommand]
    async Task Tap(TaskModel task)
        => await Shell.Current.GoToAsync(nameof(DetailPage),
            new Dictionary<string, object> { ["Task"] = task });
}