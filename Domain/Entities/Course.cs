namespace Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public required string CourseName { get; set; }
    public List<Group>? Groups { get; set; }
}