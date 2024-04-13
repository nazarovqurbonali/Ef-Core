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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        #region one to many

        modelBuilder.Entity<Course>().HasMany(x => x.Groups)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region One to one

        modelBuilder.Entity<StudentAddress>()
            .HasOne(x => x.Student)
            .WithOne(x => x.StudentAddress);

        #endregion

        #region Many to Many

        modelBuilder.Entity<StudentGroup>()
            .HasOne(x => x.Student)
            .WithMany(x => x.StudentGroups);
        
        
        modelBuilder.Entity<StudentGroup>()
            .HasOne(x => x.Group)
            .WithMany(x => x.StudentGroups);

        modelBuilder.Entity<StudentGroup>().HasKey(x => new { x.StudentId, x.GroupId });

        #endregion
        
        base.OnModelCreating(modelBuilder);
    }
}