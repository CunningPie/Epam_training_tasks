using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Lectures.Queries;

/// <summary>
/// Класс DTO для Lecture. 
/// </summary>
public class LectureDto : IMapFrom<Lecture>
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