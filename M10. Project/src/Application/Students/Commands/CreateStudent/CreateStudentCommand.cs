using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Students.Commands.CreateStudent;

/// <summary>
///  Команда создания экземпляра студента.
/// </summary>
public class CreateStudentCommand : IRequest<int>
{
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
/// Обработчик команды создания экземпляра студента.
/// </summary>
public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды создания экземпляра студента с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public CreateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на создание экземпляра студента и добавляет его в контекст базы данных.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Student()
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone
        };

        _context.Students.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}