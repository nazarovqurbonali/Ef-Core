using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required,MaxLength(100)]
    public required  string CourseName { get; set; }
    public List<Group>? Groups { get; set; }
}