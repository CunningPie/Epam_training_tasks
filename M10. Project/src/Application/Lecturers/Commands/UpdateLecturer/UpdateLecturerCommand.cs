using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Lecturers.Commands.UpdateLecturer;

/// <summary>
/// Класс обновления экземпляра лектора.
/// </summary>
public class UpdateLecturerCommand : IRequest
{
    /// <summary>
    /// Идентификатор лектора.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя лектора.
    /// </summary>
    public string?Name { get; set; }
    
    /// <summary>
    /// Email лектора.
    /// </summary>
    public string?Email { get; set; }
}

/// <summary>
/// Обработчик команды обновления экземпляра лектора.
/// </summary>
public class UpdateLecturerCommandHandler : IRequestHandler<UpdateLecturerCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды обновления экземпляра лектора с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public UpdateLecturerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос обновления экземпляра лектора.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(UpdateLecturerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Lecturers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Lecturer), request.Id);
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Email = request.Email;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}