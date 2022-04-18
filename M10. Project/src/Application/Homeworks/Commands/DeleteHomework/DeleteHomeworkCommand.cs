using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Homeworks.Commands.DeleteHomework;

/// <summary>
/// Комманда удаления экземпляра домашней работы. 
/// </summary>
public class DeleteHomeworkCommand : IRequest
{
    public int Id { get; set; }
}

/// <summary>
/// Обработчик команды удаления экземпляра домашней работы.
/// </summary>
public class DeleteHomeworkCommandHandler : IRequestHandler<DeleteHomeworkCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды удаления экземпляра домашней работы с передачей контекста базы данных.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public DeleteHomeworkCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на удаление экземпляра домашней работы.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteHomeworkCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Homeworks
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Homework), request.Id);
        }

        _context.Homeworks.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
