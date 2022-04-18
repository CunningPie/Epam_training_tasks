using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Homeworks.Commands.CreateHomework;

/// <summary>
/// Класс валидации данных при создании экземпляра домашней работы.
/// </summary>
public class CreateHomeworkCommandValidator : AbstractValidator<CreateHomeworkCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Валидирует данные, используемые при создании экземпляра домашней работы.
    /// </summary>
    /// <param name="context"></param>
    public CreateHomeworkCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(h => h.StudentId).NotEmpty();
    }
}
