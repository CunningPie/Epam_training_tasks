using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Attendance.Commands.DeleteAttendance;

/// <summary>
/// Комманда удаления экземпляра посещения. 
/// </summary>
public class DeleteLectureAttendanceCommand : IRequest
{
    public int Id { get; set; }
}

/// <summary>
/// Обработчик команды удаления экземпляра посещения.
/// </summary>
public class DeleteLectureAttendanceCommandHandler : IRequestHandler<DeleteLectureAttendanceCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды удаления экземпляра посещения с передачей контекста базы данных.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public DeleteLectureAttendanceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на удаление экземпляра посещения.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteLectureAttendanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Attendance
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(LectureAttendance), request.Id);
        }

        _context.Attendance.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}