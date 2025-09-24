using MauiApp1.Models;
using MauiApp1.Utils;

namespace MauiApp1.Providers;

public class TaskProvider : ITaskProvider
{
    private readonly List<TaskModel> _tasks = GenerateTasks.Create();
    private const int DelayMs = 400;

    public async Task<TaskModel> CreateTaskAsync(TaskModel task)
    {
        await Task.Delay(DelayMs);
        _tasks.Add(task);
        return task;
    }

    public async Task<TaskModel?> GetTaskByIdAsync(Guid id)
    {
        await Task.Delay(DelayMs);
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public async Task DeleteTaskByIdAsync(Guid id)
    {
        await Task.Delay(DelayMs);
        var index = _tasks.FindIndex(t => t.Id == id);
        if (index >= 0)
        {
            _tasks.RemoveAt(index);
        }
    }

    public async Task<TaskModel?> UpdateTaskAsync(TaskModel task)
    {
        await Task.Delay(DelayMs);
        var index = _tasks.FindIndex(t => t.Id == task.Id);
        if (index >= 0)
        {
            _tasks[index] = task;
            return _tasks[index];
        }

        return null;
    }
}