using MauiAPP1.Data.Entities;
using MauiAPP1.Data.Local;
using MauiApp1.Models;
using MauiApp1.Utils;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Providers;

public class TaskProvider(LocalDbContext localDbContext)
	: ITaskProvider
{
	// private readonly List<TaskModel> _tasks = GenerateTasks.Create();
	// private const int DelayMs = 400;

	public async Task<TaskEntity> CreateTaskAsync(TaskEntity task)
	{
		// await Task.Delay(DelayMs);
		await localDbContext.AddAsync(task);
		await localDbContext.SaveChangesAsync();
		return task;
	}

	public async Task<TaskEntity?> GetTaskByIdAsync(Guid id)
	{
		return await localDbContext.Tasks.FindAsync(id);
		// await Task.Delay(DelayMs);
		// return _tasks.FirstOrDefault(t => t.Id == id);
	}

	public async Task DeleteTaskByIdAsync(Guid id)
	{
		var task = await GetTaskByIdAsync(id);
		if (task != null)
		{
			localDbContext.Tasks.Remove(task);
			await localDbContext.SaveChangesAsync();
		}
		// await Task.Delay(DelayMs);
		// var index = _tasks.FindIndex(t => t.Id == id);
		// if (index >= 0)
		// {
		// 	_tasks.RemoveAt(index);
		// }
	}

	public async Task<TaskEntity?> UpdateTaskAsync(TaskEntity task)
	{
		var existing = await localDbContext.Tasks.FindAsync(task.Id);
		if (existing is null)
		{
			return null;
		}
		
		existing.Name = task.Name;
		existing.Description = task.Description;
		existing.DueDate = task.DueDate;

		await localDbContext.SaveChangesAsync();
		return existing;
	}

	public async Task<List<TaskEntity>> GetTasksAsync()
	{
		return await localDbContext.Tasks.ToListAsync();
	}
}
