using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Lectures.Commands.DeleteLecture;

/// <summary>
/// Комманда удаления экземпляра лекции. 
/// </summary>
public class DeleteLectureCommand : IRequest
{
    public int Id { get; set; }
}

/// <summary>
/// Обработчик команды удаления экземпляра лекции.
/// </summary>
public class DeleteLectureCommandHandler : IRequestHandler<DeleteLectureCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды удаления экземпляра лекции с передачей контекста базы данных.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public DeleteLectureCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на удаление экземпляра лекции.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteLectureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Lectures
            .FindAsync(new object[] { request.Id}, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Lecture), request.Id);
        }

        _context.Lectures.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}