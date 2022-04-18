using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Attendance.Commands.UpdateAttendance;

/// <summary>
/// Класс обновления экземпляра посещения.
/// </summary>
public class UpdateLectureAttendanceCommand : IRequest
{
    /// <summary>
    /// Идентификатор посещения.
    /// </summary>
    public int Id { get; set; }

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
    /// Оценка за лекцию.
    /// </summary>
    public int Assessment { get; set; }
    
    /// <summary>
    /// Присутствие студента.
    /// </summary>
    public bool Presence { get; set; }
}

/// <summary>
/// Обработчик команды обновления экземпляра посещения.
/// </summary>
public class UpdateLectureAttendanceCommandHandler : IRequestHandler<UpdateLectureAttendanceCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды обновления экземпляра посещения с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public UpdateLectureAttendanceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос обновления экземпляра посещения.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(UpdateLectureAttendanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Attendance
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(LectureAttendance), request.Id);
        }

        entity.Id = request.Id;
        entity.StudentId = request.StudentId;
        entity.LectureId = request.LectureId;
        entity.HomeworkId = request.HomeworkId;
        entity.Assessment = request.Assessment;
        entity.Presence = request.Presence;

        await _context.SaveChangesAsync(cancellationToken);
 
        return Unit.Value;
    }
}
