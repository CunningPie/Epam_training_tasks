using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Homework> Homeworks { get; }
    
    DbSet<Student> Students { get; }
    
    DbSet<Lecture> Lectures { get; }
    
    DbSet<Lecturer> Lecturers { get; }
    
    DbSet<LectureAttendance> Attendance { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
