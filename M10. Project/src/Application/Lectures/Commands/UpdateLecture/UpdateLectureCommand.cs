using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Lectures.Commands.UpdateLecture;

/// <summary>
/// Класс обновления экземпляра лекции.
/// </summary>
public class UpdateLectureCommand : IRequest
{
    /// <summary>
    /// Идентификатор лекции.
    /// </summary>
    public int Id { get; set; }
    
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
/// Обработчик команды обновления экземпляра лекции.
/// </summary>
public class UpdateLectureCommandHandler : IRequestHandler<UpdateLectureCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Конструктор обработчика команды обновления экземпляра лекции с передачей контекста базы данных.
    /// </summary>
    /// <param name="context"></param>
    public UpdateLectureCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Обрабатывает запрос обновления экземпляра лекции.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(UpdateLectureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Lectures
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Lecture), request.Id);
        }

        entity.Id = request.Id;
        entity.LecturerId = request.LecturerId;
        entity.Title = request.Title;
        entity.Date = request.Date;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}