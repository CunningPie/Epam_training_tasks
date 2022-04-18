using FluentValidation;

namespace CleanArchitecture.Application.Lectures.Commands.UpdateLecture;

/// <summary>
/// Класс валидации данных при обновлении экземпляра лекции.
/// </summary>
public class UpdateLectureCommandValidator : AbstractValidator<UpdateLectureCommand>
{
    /// <summary>
    /// Валидирует данные, используемые при обновлении экземпляра лекции.
    /// </summary>
    public UpdateLectureCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .NotEmpty().WithMessage("Title is required.");
        RuleFor(v => v.Date)
            .NotEmpty().WithMessage("Date is required.");
    }
}