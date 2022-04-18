using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Attendance.Queries.ExportAttendance;
/*
public class ExportAttendanceQuery : IRequest<ExportStudentsVm>
{
    //public int ListId { get; set; }
    public string? Name { get; set; }
}

public class ExportAttendanceQueryHandler : IRequestHandler<ExportAttendanceQuery, ExportStudentsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileBuilder _fileBuilder;

    public ExportAttendanceQueryHandler(IApplicationDbContext context, IMapper mapper, IFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportStudentsVm> Handle(ExportAttendanceQuery request, CancellationToken cancellationToken)
    {

        var records = await _context.Students
                .Where(t => t.Name == request.Name)
                .ProjectTo<StudentRecord>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        var records = new List<StudentRecord>();
        var vm = new ExportStudentsVm(
            "Students.csv",
            "text/csv",
            _fileBuilder.BuildAttendanceFile(records));

        return vm;
    }
}
*/