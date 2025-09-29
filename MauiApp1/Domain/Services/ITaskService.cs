using MauiApp1.Domain.Models;

namespace MauiApp1.Domain.Services;

public interface ITaskService
{
	Task<TaskModel> CreateTaskAsync(TaskModel task);

	Task<TaskModel?> GetTaskByIdAsync(Guid id);

	Task DeleteTaskByIdAsync(Guid id);

	Task<TaskModel?> UpdateTaskAsync(TaskModel task);

	Task<List<TaskModel>> GetTasksAsync();
}
