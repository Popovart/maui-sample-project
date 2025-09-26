using MauiApp1.Data.Entities;
using MauiApp1.Models;
using MauiApp1.Providers;
using MauiApp1.Mapping;

namespace MauiApp1.Services;

public class TaskService(ITaskProvider provider)
	: ITaskService
{
	public async Task<TaskModel> CreateTaskAsync(TaskModel task)
	{
		var created = await provider.CreateTaskAsync(task.ToEntity());
		var response = created.ToModel();

		return response;
	}

	public async Task<TaskModel?> GetTaskByIdAsync(Guid id)
	{
		var state = await provider.GetTaskByIdAsync(id);
		var response = state?.ToModel();

		return response;
	}

	public async Task DeleteTaskByIdAsync(Guid id)
	{
		await provider.DeleteTaskByIdAsync(id);
	}

	public async Task<TaskModel?> UpdateTaskAsync(TaskModel task)
	{
		var updated = await provider.UpdateTaskAsync(task.ToEntity());
		return updated?.ToModel();
	}

	public async Task<IEnumerable<TaskModel>> GetTasksAsync()
	{
		var state = await provider.GetTasksAsync();
		return state.Select(it => it.ToModel());
	}
}
