namespace Domain.Entities;

public class StudentAddress
{
    public int Id { get; set; }
    public required string Address { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
}