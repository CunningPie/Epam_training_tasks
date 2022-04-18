namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Класс лекции.
/// </summary>
public class Lecture
{
    /// <summary>
    /// Идентификатор лекции.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Идентификатор лектора.
    /// </summary>
    public int LecturerId { get; set; }
    
    /// <summary>
    /// Название лекции.
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// Дата проведения лекции.
    /// </summary>
    public DateTime? Date { get; set; }
}