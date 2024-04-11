namespace Domain.DTOs;

public class AddStudentDto
{
    public required string FullName { get; set; }
    public string? Phone { get; set; }
}