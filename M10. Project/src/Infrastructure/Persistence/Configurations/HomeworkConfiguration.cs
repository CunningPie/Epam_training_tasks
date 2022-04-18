using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
{
    public void Configure(EntityTypeBuilder<Homework> builder)
    {
        builder.ToTable("Homeworks");
        
        builder.Property(h => h.StudentId)
            .IsRequired();
        
        builder.HasOne<Student>().WithMany().HasForeignKey(h => h.StudentId);
    }
}