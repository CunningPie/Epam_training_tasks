using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;

/// <summary>
///  Команда создания экземпляра лектора.
/// </summary>
public class CreateLecturerCommand : IRequest<int>
{
    /// <summary>
    /// Имя лектора.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Email лектора.
    /// </summary>
    public string? Email { get; set; }
}

/// <summary>
/// Обработчик команды создания экземпляра лектора.
/// </summary>
public class CreateLecturerCommandHandler : IRequestHandler<CreateLecturerCommand, int>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды создания экземпляра лектора с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public CreateLecturerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на создание экземпляра лектора и добавляет его в контекст базы данных.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateLecturerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Lecturer()
        {
            Name = request.Name,
            Email = request.Email
        };

        _context.Lecturers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
