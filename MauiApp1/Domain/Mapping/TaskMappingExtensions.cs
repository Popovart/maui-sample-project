using MauiApp1.Domain.Models;
using MauiAPP1.Infrastructure.Entities;

namespace MauiApp1.Domain.Mapping;

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


