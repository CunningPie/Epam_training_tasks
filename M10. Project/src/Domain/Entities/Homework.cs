namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Класс домашней работы.
/// </summary>
public class Homework
{
    /// <summary>
    /// Идентификатор домашней работы.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Идентификатор студента.
    /// </summary>
    public int StudentId { get; set; }
}