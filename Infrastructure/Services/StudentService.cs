using System.Net;
using Domain.DTOs;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService(DataContext context):IStudentService
{

    public async Task<Response<List<GetStudentsDto>>> GetStudentsAsync()
    {
        try
        {
            var students = await context.Students.Where(x => x.Id > 0).ToListAsync();

            var list = new List<GetStudentsDto>();

            foreach (var s in students)
            {
                var student = new GetStudentsDto()
                {
                    FullName = s.FullName,
                    Id = s.Id,
                    Phone = s.Phone
                };
                list.Add(student);
            }

            return new Response<List<GetStudentsDto>>(list);
        }
        catch (Exception e)
        {
            return new Response<List<GetStudentsDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetStudentsDto>> GetStudentByIdAsync(int id)
    {
        var student = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
        if(student==null) return new Response<GetStudentsDto>(HttpStatusCode.BadRequest,"Student not found");
        var response = new GetStudentsDto()
        {
            FullName = student.FullName,
            Id = student.Id,
            Phone = student.Phone
        };
        return new Response<GetStudentsDto>(response);
    }

    public async Task<Response<string>> CreateStudentAsync(AddStudentDto student)
    {
        var newStudent = new Student()
        {
            FullName = student.FullName,
            Phone = student.Phone
        };
        await context.Students.AddAsync(newStudent);
       var res= await context.SaveChangesAsync();
       if(res>0) return new Response<string>("Successfully added");
       return new Response<string>("Failed to add");
    }

    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student)
    {
        var existingStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
        if(existingStudent==null) return new Response<string>("Not found");

        existingStudent.FullName = student.FullName;
        existingStudent.Phone = student.Phone;
        var res= await context.SaveChangesAsync();
        
        if(res>0) return new Response<string>("Successfully updated");
        return new Response<string>("Failed to update");
    }

    public async Task<Response<bool>> DeleteStudentAsync(int id)
    {
        var existing = await context.Students.FindAsync(id);
        if(existing== null) return new Response<bool>(HttpStatusCode.BadRequest,"Student not found");
        context.Students.Remove(existing);
        await context.SaveChangesAsync();
        return new Response<bool>(true);
    }
}