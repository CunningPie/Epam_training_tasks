using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Homeworks.Commands.UpdateHomework;

/// <summary>
/// Класс обновления экземпляра домашней работы.
/// </summary>
public class UpdateHomeworkCommand : IRequest
{
    /// <summary>
    /// Идентификатор домашней работы.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор студента - автора работы.
    /// </summary>
    public int StudentId { get; set; }
}

/// <summary>
/// Обработчик команды обновления экземпляра домашней работы.
/// </summary>
public class UpdateHomeworkCommandHandler : IRequestHandler<UpdateHomeworkCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды обновления экземпляра домашней работы с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public UpdateHomeworkCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос обновления экземпляра домашней работы.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(UpdateHomeworkCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Homeworks
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Homework), request.Id);
        }

        entity.Id = request.Id;
        entity.StudentId = request.StudentId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
