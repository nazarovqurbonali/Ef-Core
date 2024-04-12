using Domain.DTOs;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IStudentService
{
    Task<Response<List<GetStudentsDto>>> GetStudentsAsync();
    Task<Response<GetStudentsDto>> GetStudentByIdAsync(int id);
    Task<Response<string>> CreateStudentAsync(AddStudentDto student);
    Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student);
    Task<Response<bool>> DeleteStudentAsync(int id);
}