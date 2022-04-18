using CleanArchitecture.Application.Attendance.Commands.UpdateAttendance;
using FluentValidation;

/// <summary>
/// Класс валидации данных при обновлении экземпляра посещения лекции.
/// </summary>
public class UpdateLectureAttendanceCommandValidator : AbstractValidator<UpdateLectureAttendanceCommand>
{
    /// <summary>
    /// Валидирует данные, используемые при обновлении экземпляра посещения лекции.
    /// </summary>
    public UpdateLectureAttendanceCommandValidator()
    {
        When(attendance => attendance.Presence, () =>
            RuleFor(attendance => attendance.Assessment).InclusiveBetween(0, 5).WithMessage("Assessment should be in interval [0:5]"));
        When(attendance => !attendance.Presence || attendance.HomeworkId == null, () =>
            RuleFor(attendance => attendance.Assessment).Equal(0).WithMessage("Assessment should be 0 if homework id is null or Presence is false"));
    }
}