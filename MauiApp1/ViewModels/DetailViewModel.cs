using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModels;

[QueryProperty(nameof(Task), nameof(Task))]
public partial class DetailViewModel : ObservableObject
{
	[ObservableProperty]
	private TaskModel task;

	// [RelayCommand]
	// async TaskModel GoBack()
	// {
	//     await Shell.Current.GoToAsync("../");
	// }
}
