using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Homeworks.Queries;

/// <summary>
/// Запрос получения таблицы домашней работы.
/// </summary>
public class GetHomeworksQuery : IRequest<IList<HomeworkDto>>
{
}

/// <summary>
/// Обработчик запроса получения таблицы домашней работы.
/// </summary>
public class GetHomeworksQueryHandler : IRequestHandler<GetHomeworksQuery, IList<HomeworkDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор обработчика запроса получения таблицы домашней работы.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public GetHomeworksQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Обработывает запрос и возвращает список домашней работы из таблицы Homeworks.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IList<HomeworkDto>> Handle(GetHomeworksQuery request, CancellationToken cancellationToken)
    {
        return await _context.Homeworks
            .OrderBy(x => x.StudentId)
            .ProjectTo<HomeworkDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}