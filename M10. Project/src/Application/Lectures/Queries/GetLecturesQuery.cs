using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Lectures.Queries;

/// <summary>
/// Запрос получения таблицы лекций.
/// </summary>
public class GetLecturesQuery : IRequest<IList<LectureDto>>
{
}

/// <summary>
/// Обработчик запроса получения таблицы лекций.
/// </summary>
public class GetLecturesQueryHandler : IRequestHandler<GetLecturesQuery, IList<LectureDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор обработчика запроса получения таблицы лекций.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public GetLecturesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Обработывает запрос и возвращает список лекций из таблицы Lectures.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IList<LectureDto>> Handle(GetLecturesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Lectures
            .OrderBy(x => x.Title)
            .ProjectTo<LectureDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}