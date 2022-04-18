using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Attendance.Commands.CreateAttendance;

/// <summary>
/// Класс валидации данных при создании экземпляра посещения.
/// </summary>
public class CreateLectureAttendanceCommandValidator : AbstractValidator<CreateLectureAttendanceCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Валидирует данные, используемые при создании экземпляра посещения.
    /// </summary>
    /// <param name="context"></param>
    public CreateLectureAttendanceCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(a => a.StudentId).NotEmpty();
        RuleFor(a => a.LectureId).NotEmpty();

        When(attendance => attendance.Presence, () =>
            RuleFor(attendance => attendance.Assessment).InclusiveBetween(0, 5).WithMessage("Assessment should be in interval [0:5]"));
        When(attendance => !attendance.Presence || attendance.HomeworkId == null, () =>
            RuleFor(attendance => attendance.Assessment).Equal(0).WithMessage("Assessment should be 0 if homework id is null or Presence is false"));
    }
}