using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        
        builder.Property(s => s.Name)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(s => s.Email)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(s => s.Phone)
            .HasMaxLength(200)
            .IsRequired();
    }
}