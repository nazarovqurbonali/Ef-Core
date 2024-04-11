using Domain.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(IStudentService studentService):ControllerBase
{
    [HttpGet("get-students")]
    public async  Task<List<GetStudentsDto>> GetStudentsAsync()
    {
        return await studentService.GetStudentsAsync();
    }
    
    [HttpGet("{studentId:int}")]
    public async  Task<GetStudentsDto> GetStudentByIdAsync(int studentId)
    {
        return await studentService.GetStudentByIdAsync(studentId);
    }

    [HttpPost("create-student")]
    public async Task<string> CreateStudentAsync(AddStudentDto student)
    {
        return await studentService.CreateStudentAsync(student);
    }

    [HttpPut("update-student")]
    public async Task<string> UpdateStudentAsync(UpdateStudentDto student)
    {
        return await studentService.UpdateStudentAsync(student);
    }

    [HttpDelete("{studentId:int}")]
    public async Task<bool> DeleteStudentAsync(int studentId)
    {
        return await studentService.DeleteStudentAsync(studentId);
    }
}