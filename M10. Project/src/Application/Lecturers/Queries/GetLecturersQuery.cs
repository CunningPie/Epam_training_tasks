using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Lecturers.Queries;

/// <summary>
/// Запрос получения таблицы лекторов.
/// </summary>
public class GetLecturersQuery : IRequest<IList<LecturerDto>>
{
}

/// <summary>
/// Обработчик запроса получения таблицы лекторов.
/// </summary>
public class GetLecturersQueryHandler : IRequestHandler<GetLecturersQuery, IList<LecturerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор обработчика запроса получения таблицы лекторов.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public GetLecturersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Обработывает запрос и возвращает список лекций из таблицы Lecturers.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IList<LecturerDto>> Handle(GetLecturersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Lecturers
            .OrderBy(x => x.Name)
            .ProjectTo<LecturerDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}