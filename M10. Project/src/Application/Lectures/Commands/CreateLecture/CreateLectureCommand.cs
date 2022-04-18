using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Lectures.Commands.CreateLecture;

/// <summary>
///  Команда создания экземпляра лекции.
/// </summary>
public class CreateLectureCommand : IRequest<int>
{
    /// <summary>
    /// Идентификатор лектора.
    /// </summary>
    public int LecturerId { get; set; }

    /// <summary>
    /// Название лекции.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Дата проведения лекции.
    /// </summary>
    public DateTime? Date { get; set; }
}

/// <summary>
/// Обработчик команды создания экземпляра лекции.
/// </summary>
public class CreateLectureCommandHandler : IRequestHandler<CreateLectureCommand, int>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды создания экземпляра лекции с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public CreateLectureCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос на создание экземпляра лекции и добавляет его в контекст базы данных.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateLectureCommand request, CancellationToken cancellationToken)
    {
        var entity = new Lecture()
        {
            LecturerId = request.LecturerId,
            Title = request.Title,
            Date = request.Date
        };

        _context.Lectures.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}