using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
{
    public void Configure(EntityTypeBuilder<Lecture> builder)
    {
        builder.ToTable("Lectures");

        builder.Property(l => l.Title)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(l => l.LecturerId)
            .IsRequired();
        builder.Property(l => l.Date)
            .IsRequired();

        builder.HasOne<Lecturer>().WithMany().HasForeignKey(l => l.LecturerId);
    }
}