using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Lecturers.Queries;

/// <summary>
/// Класс DTO для Lecturer. 
/// </summary>
public class LecturerDto : IMapFrom<Lecturer>
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