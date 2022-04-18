using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Lectures.Commands.CreateLecture;

/// <summary>
/// Класс валидации данных при создании нового экземпляра лекции.
/// </summary>
public class CreateLectureCommandValidator : AbstractValidator<CreateLectureCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Валидирует данные, используемые при создании нового экземпляра лекции.
    /// </summary>
    /// <param name="context"></param>
    public CreateLectureCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .NotEmpty().WithMessage("Title is required.");
        RuleFor(v => v.Date)
            .NotEmpty().WithMessage("Date is required.");
    }
}