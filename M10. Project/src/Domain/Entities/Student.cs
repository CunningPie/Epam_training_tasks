namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Класс студента.
/// </summary>
public class Student
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