using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Attendance.Queries.ExportAttendance;

/// <summary>
/// Класс записи посещения.
/// </summary>
public class StudentRecord : IMapFrom<Student>
{
    /// <summary>
    /// Имя студента.
    /// </summary>
    public string? Name { get; set; }
    
    
}