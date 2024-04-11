using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService(DataContext context):IStudentService
{

    public async Task<List<GetStudentsDto>> GetStudentsAsync()
    {
        var students = await context.Students.Where(x=>x.Id>0).ToListAsync();

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
        return list;
    }

    public async Task<GetStudentsDto> GetStudentByIdAsync(int id)
    {
        var student = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
        var response = new GetStudentsDto()
        {
            FullName = student.FullName,
            Id = student.Id,
            Phone = student.Phone
        };
        return response;
    }

    public async Task<string> CreateStudentAsync(AddStudentDto student)
    {
        var newStudent = new Student()
        {
            FullName = student.FullName,
            Phone = student.Phone
        };
        await context.Students.AddAsync(newStudent);
       var res= await context.SaveChangesAsync();
       if(res>0) return "Successfully added";
       return "Failed to add";
    }

    public async Task<string> UpdateStudentAsync(UpdateStudentDto student)
    {
        var existingStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
        if(existingStudent==null) return "Not found";

        existingStudent.FullName = student.FullName;
        existingStudent.Phone = student.Phone;
        var res= await context.SaveChangesAsync();
        
        if(res>0) return "Successfully updated";
         return "Failed to update";
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var existing = await context.Students.FindAsync(id);
        if(existing== null) return false;
        context.Students.Remove(existing);
        await context.SaveChangesAsync();
        return true;
    }
}