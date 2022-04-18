using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Homeworks.Commands.CreateHomework;

/// <summary>
///  Команда создания экземпляра домашней работы.
/// </summary>
public class CreateHomeworkCommand : IRequest<int>
{
    /// <summary>
    /// Идентификатор студента.
    /// </summary>
    public int StudentId { get; set; }
}

/// <summary>
/// Обработчик команды создания экземпляра домашней работы.
/// </summary>
public class CreateHomeworkCommandHandler : IRequestHandler<CreateHomeworkCommand, int>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды создания экземпляра домашней работы с передачей контекста базы данных.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public CreateHomeworkCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на создание экземпляра домашней работы и добавляет его в контекст базы данных.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateHomeworkCommand request, CancellationToken cancellationToken)
    {
        var entity = new Homework
        {
            StudentId = request.StudentId
        };

        _context.Homeworks.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
