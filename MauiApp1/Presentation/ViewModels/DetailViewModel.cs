using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Domain.Models;

namespace MauiApp1.Presentation.ViewModels;

[QueryProperty(nameof(TaskData), nameof(TaskData))]
public partial class DetailViewModel : ObservableObject
{
	[ObservableProperty]
	private TaskModel taskData;

	// [RelayCommand]
	// async TaskModel GoBack()
	// {
	//     await Shell.Current.GoToAsync("../");
	// }
}
