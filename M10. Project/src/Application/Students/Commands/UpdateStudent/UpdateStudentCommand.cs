using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Students.Commands.UpdateStudent;

/// <summary>
/// Класс обновления экземпляра студента.
/// </summary>
public class UpdateStudentCommand : IRequest
{
    /// <summary>
    /// Идентификатор студента.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя студента.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Email студента.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Номер студента.
    /// </summary>
    public string? Phone { get; set; }
}

/// <summary>
/// Обработчик команды обновления экземпляра студента.
/// </summary>
public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды обновления экземпляра студента с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public UpdateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос обновления экземпляра студента.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Students
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Student), request.Id);
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Email = request.Email;
        entity.Phone = request.Phone;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}