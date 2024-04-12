namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public required string GroupName { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public List<StudentGroup>? StudentGroups { get; set; }
}