using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<StudentAddress> StudentAddresses { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<Student> Students { get; set; }
}