using MauiApp1.Models;

namespace MauiApp1.Services;

public interface ITaskService
{
    Task<TaskModel> CreateTaskAsync(TaskModel task);
    
    Task<TaskModel?> GetTaskByIdAsync(Guid id);
    
    Task DeleteTaskByIdAsync(Guid id);
    
    Task<TaskModel?> UpdateTaskAsync(TaskModel task);
}