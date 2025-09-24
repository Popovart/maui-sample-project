using MauiApp1.Models;

namespace MauiApp1.Providers;

public interface ITaskProvider
{
    Task<TaskModel> CreateTaskAsync(TaskModel task);
    
    Task<TaskModel?> GetTaskByIdAsync(Guid id);
    
    Task DeleteTaskByIdAsync(Guid id);
    
    Task<TaskModel?> UpdateTaskAsync(TaskModel task);
}