using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class LectureAttendanceConfiguration : IEntityTypeConfiguration<LectureAttendance>
{
    public void Configure(EntityTypeBuilder<LectureAttendance> builder)
    {
        builder.ToTable("Attendance");

        builder.Property(a => a.Assessment)
            .IsRequired();
        
        builder.HasOne<Student>().WithMany().HasForeignKey(a => a.StudentId);
        builder.HasOne<Homework>().WithMany().HasForeignKey(a => a.HomeworkId);
        builder.HasOne<Lecture>().WithMany().HasForeignKey(a => a.LectureId);
    }
}