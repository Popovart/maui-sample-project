using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Domain.Models;
using MauiApp1.Domain.ModelValidation;
using MauiApp1.Domain.Services;

namespace MauiApp1.Presentation.ViewModels;

public partial class TaskPopupViewModel(
	IPopupService popupService,
	ITaskService taskService
) : ObservableObject, IQueryAttributable
{
	// [NotifyCanExecuteChangedFor(nameof(OnSaveCommand))] - don't now the reason for that
	[ObservableProperty]
	TaskModel taskData = new(Guid.NewGuid(), "", "", "");

	[ObservableProperty]
	string nameInput;

	[ObservableProperty]
	string descriptionInput;

	[ObservableProperty]
	string dueDateInput;

	public void ApplyQueryAttributes(
		IDictionary<string, object> query
	)
	{
		TaskData = (TaskModel)query[nameof(TaskData)];
		if (TaskData != null)
		{
			NameInput = TaskData.Name;
			DescriptionInput = TaskData.Description;
			DueDateInput = TaskData.DueDate;
		}
	}

	// public async void ApplyQueryAttributes(IDictionary<string, object> query)
	// {
	//     // var id = (Guid)query[nameof(TaskData)];
	//     // _ = LoadTaskAsync(id);
	//     TaskData = await taskService.GetTaskByIdAsync((Guid)query[nameof(TaskData)]);
	// }

	// private async Task LoadTaskAsync(Guid id)
	// {
	//     var item = await taskService.GetTaskByIdAsync(id);
	//     if (item != null) TaskData = item;
	// }

	[RelayCommand]
	public async Task OnCancel()
	{
		await popupService.ClosePopupAsync(Shell.Current);
	}

	[RelayCommand(CanExecute = nameof(CanSave))]
	async Task OnSave()
	{
		TaskData = TaskData with
		{
			Name = NameInput,
			Description = DescriptionInput,
			DueDate = DueDateInput,
		};

		await popupService.ClosePopupAsync<TaskModel>(Shell.Current, TaskData);
	}

	bool CanSave() => TaskModelExtensions.IsValid(TaskData);
}
