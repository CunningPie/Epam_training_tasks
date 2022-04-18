using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;

/// <summary>
/// Класс валидации данных при создании нового экземпляра лектора.
/// </summary>
public class CreateLecturerCommandValidator : AbstractValidator<CreateLecturerCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Валидирует данные, используемые при создании нового экземпляра лектора.
    /// </summary>
    /// <param name="context"></param>
    public CreateLecturerCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
            .NotEmpty().WithMessage("Name is required.");
        RuleFor(v => v.Email)
            .MaximumLength(200).WithMessage("Email must not exceed 200 characters.")
            .NotEmpty().WithMessage("Email is required.")
            .MustAsync(BeUniqueEmail).WithMessage("The specified email already exists.");
    }
    
    /// <summary>
    /// Проверяет уникальность email в таблице Lecturers.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Lecturers
            .AllAsync(l => l.Email != email, cancellationToken);
    }
}