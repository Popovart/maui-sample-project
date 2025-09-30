using System.Collections.ObjectModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Domain.Models;
using MauiApp1.Domain.Services;
using MauiApp1.Domain.Services.NavigationService;
using MauiApp1.Presentation.Popups;
using MauiApp1.Presentation.ViewModels.Base;
using MauiApp1.Presentation.Views;
using Microsoft.Maui.Controls.Shapes;

namespace MauiApp1.Presentation.ViewModels;

public partial class MainViewModel(
	IPopupService popupService,
	ITaskService taskService,
	INavigationService navigationService
) : BaseViewModel(navigationService)
{
	private bool _isInitialized;
	
	[ObservableProperty]
	ObservableCollection<TaskModel> _tasksList = new();

	[ObservableProperty] private string _taskName = String.Empty;
	
	// async Task RefreshAsync()
	// {
	// 	var list = await taskService.GetTasksAsync();
	// 	TasksList.Clear();
	// 	TasksList = list.ToObservableCollection();
	// }
	
	public override async Task InitializeAsync()
	{
		if (_isInitialized)
		{
			return;
		}

		_isInitialized = true;
		await IsBusyFor(
			async () =>
			{
				TasksList = await InitTaskList();
			});
	}

	async Task<ObservableCollection<TaskModel>> InitTaskList()
	{
		return (await taskService.GetTasksAsync()).ToObservableCollection();
	}

	[RelayCommand]
	async Task Add()
	{
		if (string.IsNullOrWhiteSpace(TaskName))
			return;
		var newTask = new TaskModel(
			Guid.NewGuid(),
			TaskName,
			null,
			DateTime.UtcNow.ToString("u")
		);
		
		await IsBusyFor(
			async () =>
			{
				var response = await taskService.CreateTaskAsync(newTask);
				TasksList.Add(response);
				TaskName = string.Empty;
			});
	}

	[RelayCommand]
	async Task Delete(TaskModel task)
	{
		await taskService.DeleteTaskByIdAsync(task.Id);
		if (TasksList.Contains(task))
		{
			TasksList.Remove(task);
		}
	}

	[RelayCommand]
	async Task Tap(TaskModel task) =>
		await Shell.Current.GoToAsync(
			nameof(DetailPage),
			new Dictionary<string, object> { ["Task"] = task }
		);

	// [RelayCommand]
	// async Task DisplayPopup(TaskModel task)
	// {
	// 	var popupOptions = new PopupOptions
	// 	{
	// 		CanBeDismissedByTappingOutsideOfPopup = false,
	// 		Shape = new RoundRectangle
	// 		{
	// 			CornerRadius = new CornerRadius(10, 10, 10, 10),
	// 			StrokeThickness = 2,
	// 			Stroke = Colors.LightGray,
	// 		},
	// 	};
	//
	// 	var queryAttributes = new Dictionary<string, object>();
	//
	// 	queryAttributes = new Dictionary<string, object>
	// 	{
	// 		[nameof(TaskPopupViewModel.TaskData)] = task,
	// 	};
	//
	// 	var result = await popupService.ShowPopupAsync<TaskPopupViewModel>(
	// 		Shell.Current,
	// 		options: popupOptions,
	// 		shellParameters: queryAttributes
	// 	);
	//
	// 	if (result.WasDismissedByTappingOutsideOfPopup)
	// 		return;
	//
	// 	if (result is IPopupResult<TaskModel> { Result: { } updated })
	// 	{
	// 		await taskService.UpdateTaskAsync(updated);
	//
	// 		var found = Items.FirstOrDefault(t => t.Id == updated.Id);
	// 		if (found is null)
	// 			return;
	//
	// 		var ix = Items.IndexOf(found);
	// 		if (ix >= 0)
	// 			Items[ix] = updated;
	// 		await Tap(found);
	// 	}
	// }

	[RelayCommand]
	async Task DisplayComplexPopup(TaskModel task)
	{
		var popupOptions = new PopupOptions
		{
			CanBeDismissedByTappingOutsideOfPopup = false,
			Shape = new RoundRectangle
			{
				CornerRadius = new CornerRadius(10, 10, 10, 10),
				StrokeThickness = 2,
				Stroke = Colors.Black,
			},
		};

		var queryAttributes = new Dictionary<string, object>();

		queryAttributes = new Dictionary<string, object>
		{
			[nameof(TaskPopupViewModel.TaskData)] = task,
		};

		var result =
			await popupService.ShowPopupAsync<ComplexTaskPopup>(
				Shell.Current,
				options: popupOptions,
				shellParameters: queryAttributes
			);

		if (result.WasDismissedByTappingOutsideOfPopup)
			return;

		if (result is IPopupResult<TaskModel> { Result: { } updated })
		{
			var response = await taskService.UpdateTaskAsync(updated);
			if (response == null)
				throw new Exception("something got wrong, while updating");

			var found = Enumerable.FirstOrDefault<TaskModel>(TasksList, t => t.Id == updated.Id);
			if (found is null)
				return;

			var ix = TasksList.IndexOf(found);
			if (ix >= 0)
				TasksList[ix] = response;
			await Tap(response);
		}
	}
}
