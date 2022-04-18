using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Lecturers.Commands.DeleteLecturer;

/// <summary>
/// Комманда удаления экземпляра лектора. 
/// </summary>
public class DeleteLecturerCommand : IRequest
{
    public int Id { get; set; }
}

/// <summary>
/// Обработчик команды удаления экземпляра лектора.
/// </summary>
public class DeleteLecturerCommandHandler : IRequestHandler<DeleteLecturerCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды удаления экземпляра лектора с передачей контекста базы данных.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public DeleteLecturerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на удаление экземпляра лектора.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteLecturerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Lecturers
            .FindAsync(new object[] { request.Id}, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Lecturer), request.Id);
        }

        _context.Lecturers.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}