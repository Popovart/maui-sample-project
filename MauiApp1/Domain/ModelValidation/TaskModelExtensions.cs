using MauiApp1.Domain.Models;

namespace MauiApp1.Domain.ModelValidation;

public static class TaskModelExtensions
{
	public static bool IsValid(this TaskModel? task)
	{
		if (task is null)
			return false;
		if (string.IsNullOrWhiteSpace(task.Name))
			return false;
		if (string.IsNullOrWhiteSpace(task.DueDate))
			return false;
		return true;
	}
}
