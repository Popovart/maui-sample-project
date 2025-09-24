using System.Collections.ObjectModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Popups;
using MauiApp1.Services;
using MauiApp1.Views;
using Microsoft.Maui.Controls.Shapes;

namespace MauiApp1.ViewModels;

public partial class MainViewModel(IPopupService popupService, ITaskService taskService) : ObservableObject
{

    [ObservableProperty]
    ObservableCollection<TaskModel> items = new();
    
    [ObservableProperty]
    string taskName;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(TaskName)) return;
        var newTask = new TaskModel(
            Guid.NewGuid(),
            TaskName,
            null,
            DateTime.UtcNow.ToString("u"));

        var response = await taskService.CreateTaskAsync(newTask);
        Items.Add(response);
        TaskName = string.Empty;
    }

    [RelayCommand]
    void Delete(TaskModel task)
    {
        if (Items.Contains(task))
        {
            Items.Remove(task);
        }
    }

    [RelayCommand]
    async Task Tap(TaskModel task)
        => await Shell.Current.GoToAsync(nameof(DetailPage),
            new Dictionary<string, object> { ["Task"] = task });
    
    [RelayCommand]
    async Task DisplayPopup(TaskModel task)
    {

        var popupOptions = new PopupOptions
        {
            CanBeDismissedByTappingOutsideOfPopup = false,
            Shape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(10, 10, 10, 10),
                StrokeThickness = 2,
                Stroke = Colors.LightGray
            }
        };

        var queryAttributes = new Dictionary<string, object>();
        
        queryAttributes = new Dictionary<string, object>{
            [nameof(TaskPopupViewModel.TaskData)] = task
        };
        
        var result = await popupService.ShowPopupAsync<TaskPopupViewModel>(Shell.Current,
            options: popupOptions,
            shellParameters: queryAttributes);
        
        if (result.WasDismissedByTappingOutsideOfPopup)
            return;
        
        
        if (result is IPopupResult<TaskModel> { Result: { } updated })
        {
            await taskService.UpdateTaskAsync(updated);

            var found = Items.FirstOrDefault(t => t.Id == updated.Id);
            if (found is null) return;                

            var ix = Items.IndexOf(found);             
            if (ix >= 0) Items[ix] = updated;
        }
        

    }
    
    
    
}