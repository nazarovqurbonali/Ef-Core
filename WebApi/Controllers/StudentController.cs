using Domain.DTOs;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(IStudentService studentService):ControllerBase
{
    [HttpGet("get-students")]
    public async  Task<Response<List<GetStudentsDto>>> GetStudentsAsync()
    {
        return await studentService.GetStudentsAsync();
    }
    
    [HttpGet("{studentId:int}")]
    public async  Task<Response<GetStudentsDto>> GetStudentByIdAsync(int studentId)
    {
        return await studentService.GetStudentByIdAsync(studentId);
    }

    [HttpPost("create-student")]
    public async Task<Response<string>> CreateStudentAsync(AddStudentDto student)
    {
        return await studentService.CreateStudentAsync(student);
    }

    [HttpPut("update-student")]
    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student)
    {
        return await studentService.UpdateStudentAsync(student);
    }

    [HttpDelete("{studentId:int}")]
    public async Task<Response<bool>> DeleteStudentAsync(int studentId)
    {
        return await studentService.DeleteStudentAsync(studentId);
    }
}