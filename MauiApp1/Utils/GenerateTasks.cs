using MauiApp1.Models;

namespace MauiApp1.Utils;

public static class GenerateTasks
{
	public static List<TaskModel> Create(
		int count = 20,
		int? seed = null
	)
	{
		var random = seed.HasValue
			? new Random(seed.Value)
			: new Random();
		var items = new List<TaskModel>(count);

		for (var i = 1; i <= count; i++)
		{
			var id = Guid.NewGuid();
			var name =
				$"Task #{i}: {SampleTitles[random.Next(SampleTitles.Length)]}";
			var description =
				random.NextDouble() < 0.7
					? SampleDescriptions[
						random.Next(SampleDescriptions.Length)
					]
					: null;
			var dueDate = DateTime
				.UtcNow.AddDays(random.Next(0, 14))
				.AddHours(random.Next(0, 24))
				.ToString("u");

			items.Add(new TaskModel(id, name, description, dueDate));
		}

		return items;
	}

	private static readonly string[] SampleTitles =
	{
		"Fix layout",
		"Implement login",
		"Refactor view model",
		"Wire DI",
		"Write unit tests",
		"Polish animations",
		"Improve performance",
		"Add localization",
		"Tune styles",
		"Update icons",
	};

	private static readonly string[] SampleDescriptions =
	{
		"Small change to verify binding works.",
		"Track a null-ref when navigating to details.",
		"Add missing converters and validations.",
		"Split large method into smaller ones.",
		"Replace dummy data with provider.",
		"Review margins and paddings for consistency.",
	};
}
