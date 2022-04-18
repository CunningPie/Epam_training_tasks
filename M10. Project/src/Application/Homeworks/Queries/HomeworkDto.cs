using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Homeworks.Queries;

/// <summary>
/// Класс DTO для Homework. 
/// </summary>
public class HomeworkDto : IMapFrom<Homework>
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