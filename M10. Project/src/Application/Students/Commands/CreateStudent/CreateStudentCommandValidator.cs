using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Students.Commands.CreateStudent;

/// <summary>
/// Класс валидации данных при создании нового экземпляра студента.
/// </summary>
public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Валидирует данные, используемые при создании нового экземпляра студента.
    /// </summary>
    /// <param name="context"></param>
    public CreateStudentCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
            .NotEmpty().WithMessage("Name is required.");
        
        RuleFor(v => v.Email)
            .MaximumLength(200).WithMessage("Email must not exceed 200 characters.")
            .NotEmpty().WithMessage("Email is required.")
            .MustAsync(BeUniqueEmail).WithMessage("The specified email already exists.");
        
        RuleFor(v => v.Phone)
            .MaximumLength(200).WithMessage("Phone must not exceed 200 characters.")
            .NotEmpty().WithMessage("Phone is required.")
            .MustAsync(BeUniquePhone).WithMessage("The specified phone already exists.");
    }
    
    /// <summary>
    /// Проверяет уникальность email в таблице Students.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Students
            .AllAsync(l => l.Email != email, cancellationToken);
    }
    
    /// <summary>
    /// Проверяет уникальность номера в таблице Students.
    /// </summary>
    /// <param name="phone"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> BeUniquePhone(string phone, CancellationToken cancellationToken)
    {
        return await _context.Students
            .AllAsync(l => l.Phone != phone, cancellationToken);
    }
}