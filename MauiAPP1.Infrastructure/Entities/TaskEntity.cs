using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiAPP1.Infrastructure.Entities;

[Table("Tasks")]
public class TaskEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
	
    [Column("name")]
    [Required]
    public string Name { get; set; }
	
    [Column("description")]
    public string? Description { get; set; }
	
    [Column("due_date")]
    public string DueDate { get; set; }
}