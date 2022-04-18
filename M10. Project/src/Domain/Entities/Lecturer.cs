namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Класс лектора.
/// </summary>
public class Lecturer
{
    /// <summary>
    /// Идентификатор лектора.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя лектора.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Email лектора.
    /// </summary>
    public string? Email { get; set; }
}