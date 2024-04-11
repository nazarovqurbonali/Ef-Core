namespace Domain.DTOs;

public class GetStudentsDto
{
    public int  Id { get; set; }
    public required string FullName { get; set; }
    public string? Phone { get; set; }
}