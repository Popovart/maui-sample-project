

namespace MauiApp1.Model;

public record Task(
    Guid Id,
    string Name,
    string Description,
    string DueDate
);