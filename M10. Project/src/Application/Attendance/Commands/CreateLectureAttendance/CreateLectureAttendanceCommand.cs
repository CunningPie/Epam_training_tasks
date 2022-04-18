using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Attendance.Commands.CreateAttendance;

/// <summary>
///  Команда создания экземпляра посещения.
/// </summary>
public class CreateLectureAttendanceCommand : IRequest<int>
{
    /// <summary>
    /// Идентификатор студента.
    /// </summary>
    public int StudentId { get; set; }
    
    /// <summary>
    /// Идентификатор лекции.
    /// </summary>
    public int LectureId { get; set; }
    
    /// <summary>
    /// Идентификатор домашней работы.
    /// </summary>
    public int? HomeworkId { get; set; }
    
    /// <summary>
    /// Присутствие студента.
    /// </summary>
    public bool Presence { get; set; }
    
    /// <summary>
    /// Оценка.
    /// </summary>
    public int Assessment { get; set; }
}

/// <summary>
/// Обработчик команды создания экземпляра посещения.
/// </summary>
public class CreateLectureAttendanceCommandHandler : IRequestHandler<CreateLectureAttendanceCommand, int>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды создания экземпляра посещения с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public CreateLectureAttendanceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на создание экземпляра посещения и добавляет его в контекст базы данных.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateLectureAttendanceCommand request, CancellationToken cancellationToken)
    {
        var entity = new LectureAttendance()
        {
            StudentId = request.StudentId,
            LectureId = request.LectureId,
            HomeworkId = request.HomeworkId,
            Assessment = request.Assessment,
            Presence = request.Presence
        };

        _context.Attendance.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}