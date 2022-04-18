using FluentValidation;

namespace CleanArchitecture.Application.Homeworks.Commands.UpdateHomework;

/// <summary>
/// Класс валидации данных при обновлении экземпляра домашней работы.
/// </summary>
public class UpdateHomeworkCommandValidator : AbstractValidator<UpdateHomeworkCommand>
{
    /// <summary>
    /// Валидирует данные, используемые при обновлении экземпляра домашней работы.
    /// </summary>
    public UpdateHomeworkCommandValidator()
    {
    }
}