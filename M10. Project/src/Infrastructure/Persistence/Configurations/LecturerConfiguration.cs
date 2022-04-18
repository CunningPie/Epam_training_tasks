using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
{
    public void Configure(EntityTypeBuilder<Lecturer> builder)
    {
        builder.ToTable("Lecturers");

        builder.Property(s => s.Name)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(s => s.Email)
            .HasMaxLength(200)
            .IsRequired();
    }
}