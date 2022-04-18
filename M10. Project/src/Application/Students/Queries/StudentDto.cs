using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Students.Queries;

/// <summary>
/// Класс DTO для Student. 
/// </summary>
public class StudentDto : IMapFrom<Student>
{
    /// <summary>
    /// Идентификатор студента.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя студента.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Email студента.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Номер телефона студента.
    /// </summary>
    public string? Phone { get; set; }
}