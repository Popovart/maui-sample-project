namespace MauiApp1.Domain.Models;

public record TaskModel(
	Guid Id,
	string Name,
	string? Description,
	string DueDate
);
