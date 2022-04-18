using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Attendance.Queries.GetAttendance;

/// <summary>
/// Запрос получения таблицы посещаемости.
/// </summary>
public class GetAttendanceQuery : IRequest<IList<AttendanceDto>>
{
}

/// <summary>
/// Обработчик запроса получения таблицы посещаемости.
/// </summary>
public class GetAttendanceQueryHandler : IRequestHandler<GetAttendanceQuery, IList<AttendanceDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор обработчика запроса получения таблицы посещаемости.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public GetAttendanceQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Обработывает запрос и возвращает список посещаемости из таблицы Attendance.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IList<AttendanceDto>> Handle(GetAttendanceQuery request, CancellationToken cancellationToken)
    {
        return await _context.Attendance
            .OrderBy(x => x.LectureId)
            .ProjectTo<AttendanceDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}