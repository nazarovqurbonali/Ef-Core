using Domain.DTOs;

namespace Infrastructure.Services;

public interface IStudentService
{
    Task<List<GetStudentsDto>> GetStudentsAsync();
    Task<GetStudentsDto> GetStudentByIdAsync(int id);
    Task<string> CreateStudentAsync(AddStudentDto student);
    Task<string> UpdateStudentAsync(UpdateStudentDto student);
    Task<bool> DeleteStudentAsync(int id);
}