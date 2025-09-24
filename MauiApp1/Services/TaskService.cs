using MauiApp1.Models;
using MauiApp1.Providers;

namespace MauiApp1.Services;

public class TaskService (
    ITaskProvider provider
) : ITaskService {
    public async Task<TaskModel> CreateTaskAsync(TaskModel task)
    {
        return await provider.CreateTaskAsync(task);
    }

    public async Task<TaskModel?> GetTaskByIdAsync(Guid id)
    {
        return await provider.GetTaskByIdAsync(id);
    }

    public async Task DeleteTaskByIdAsync(Guid id)
    {
        await provider.DeleteTaskByIdAsync(id);
    }

    public async Task<TaskModel?> UpdateTaskAsync(TaskModel task)
    {
        return await provider.UpdateTaskAsync(task);
    }
}