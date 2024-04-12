namespace Domain.Entities;

public class Student
{
    public int  Id { get; set; }
    public required string FullName { get; set; }
    public string? Phone { get; set; }
    public List<StudentGroup>? StudentGroups { get; set; }
    public StudentAddress? StudentAddress { get; set; }
}