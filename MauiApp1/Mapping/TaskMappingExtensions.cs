using MauiAPP1.Data.Entities;
using MauiApp1.Models;

namespace MauiApp1.Mapping;

public static class TaskMappingExtensions
{
	public static TaskEntity ToEntity(this TaskModel model)
	{
		return new TaskEntity
		{
			Id = model.Id,
			Name = model.Name,
			Description = model.Description,
			DueDate = model.DueDate,
		};
	}

	public static TaskModel ToModel(this TaskEntity entity)
	{
		return new TaskModel(
			entity.Id,
			entity.Name,
			entity.Description,
			entity.DueDate
		);
	}
}


