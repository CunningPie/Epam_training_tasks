using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Students.Queries;

/// <summary>
/// Запрос получения таблицы студентов.
/// </summary>
public class GetStudentsQuery : IRequest<IList<StudentDto>>
{
}

/// <summary>
/// Обработчик запроса получения таблицы студентов.
/// </summary>
public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IList<StudentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор обработчика запроса получения таблицы студентов.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public GetStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Обработывает запрос и возвращает список студентов из таблицы Students.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IList<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Students
            .OrderBy(x => x.Name)
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}