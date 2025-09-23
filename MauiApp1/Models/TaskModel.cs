

namespace MauiApp1.Models;

public record TaskModel(
    Guid Id,
    string Name,
    string? Description,
    string DueDate
);