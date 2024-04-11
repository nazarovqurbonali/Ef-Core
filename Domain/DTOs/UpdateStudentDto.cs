namespace Domain.DTOs;

public class UpdateStudentDto
{
    public int  Id { get; set; }
    public required string FullName { get; set; }
    public string? Phone { get; set; }
}