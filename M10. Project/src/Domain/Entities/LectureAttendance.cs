namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Класс посещаемости лекции.
/// </summary>
public class LectureAttendance
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