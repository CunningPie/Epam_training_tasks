using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Students.Commands.DeleteStudent;

/// <summary>
/// Комманда удаления экземпляра студента. 
/// </summary>
public class DeleteStudentCommand : IRequest
{
    public int Id { get; set; }
}

/// <summary>
/// Обработчик команды удаления экземпляра студента.
/// </summary>
public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды удаления экземпляра студента с передачей контекста базы данных.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public DeleteStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на удаление экземпляра студента.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Students
            .FindAsync(new object[] { request.Id}, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Student), request.Id);
        }

        _context.Students.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}