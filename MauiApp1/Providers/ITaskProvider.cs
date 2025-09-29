using MauiAPP1.Infrastructure.Entities;

namespace MauiApp1.Providers;

public interface ITaskProvider
{
	Task<TaskEntity> CreateTaskAsync(TaskEntity task);

	Task<TaskEntity?> GetTaskByIdAsync(Guid id);

	Task DeleteTaskByIdAsync(Guid id);

	Task<TaskEntity?> UpdateTaskAsync(TaskEntity task);

	Task<List<TaskEntity>> GetTasksAsync();
}
