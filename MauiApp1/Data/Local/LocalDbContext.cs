using MauiApp1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Data.Local;

public class LocalDbContext : DbContext
{
	public DbSet<TaskEntity> Tasks { get; set; }

	public LocalDbContext(DbContextOptions<LocalDbContext> options)
		: base(options)
	{
		// SQLitePCL.Batteries_V2.Init();
		// Database.Migrate(); //  TODO: migrations

		Database.EnsureCreated();
	}

	protected override void OnConfiguring(
		DbContextOptionsBuilder optionsBuilder
	)
	{
		var sqlitePath = Path.Combine(
			Environment.GetFolderPath(
				Environment.SpecialFolder.LocalApplicationData
			),
			"LocalDb.db"
		);
		optionsBuilder.UseSqlite($"Data Source={sqlitePath}");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	    base.OnModelCreating(modelBuilder);
	
	    modelBuilder.Entity<TaskEntity>(e =>
	    {
		    e.ToTable("Tasks");
		    e.HasKey(x => x.Id);
		    e.Property(x => x.Id).HasColumnName("id");
		    e.Property(x => x.Name).HasColumnName("name").IsRequired();
		    e.Property(x => x.Description).HasColumnName("description");
		    e.Property(x => x.DueDate).HasColumnName("due_date").IsRequired();
	    });
	}
}
