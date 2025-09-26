using MauiApp1.Data.Entities;
using MauiApp1.Models;

namespace MauiApp1.Providers;

public interface ITaskProvider
{
	Task<TaskEntity> CreateTaskAsync(TaskEntity task);

	Task<TaskEntity?> GetTaskByIdAsync(Guid id);

	Task DeleteTaskByIdAsync(Guid id);

	Task<TaskEntity?> UpdateTaskAsync(TaskEntity task);

	Task<IEnumerable<TaskEntity>> GetTasksAsync();
}
