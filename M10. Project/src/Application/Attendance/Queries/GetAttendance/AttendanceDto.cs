using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Attendance.Queries.GetAttendance;

/// <summary>
/// Класс DTO для Attendance. 
/// </summary>
public class AttendanceDto : IMapFrom<LectureAttendance>
{
    /// <summary>
    /// Идентификатор посещения.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Идентификатор лекции.
    /// </summary>
    public int LectureId { get; set; }
    
    /// <summary>
    /// Идентификатор студента.
    /// </summary>
    public int StudentId { get; set; }
    
    /// <summary>
    /// Идентификатор домашней работы.
    /// </summary>
    public int? HomeworkId { get; set; }
    
    /// <summary>
    /// Присутствие.
    /// </summary>
    public bool Presence { get; set; }
    
    /// <summary>
    /// Оценка, выставленная студенту на лекции.
    /// </summary>
    public int Assessment { get; set; }
}