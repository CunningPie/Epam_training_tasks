using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Attendance.Queries.ExportAttendance;
/*
public class ExportStudentAttendanceQuery : IRequest<ExportAttendanceVm>
{
    public string? Name;
}

public class ExportStudentAttendanceQueryHandler : IRequestHandler<ExportStudentAttendanceQuery, ExportAttendanceVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileBuilder _fileBuilder;

    public ExportStudentAttendanceQueryHandler(IApplicationDbContext context, IMapper mapper, IFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    private async Task<List<AttendanceRecord>> AttendanceDataRequest(ExportStudentAttendanceQuery request, CancellationToken cancellationToken)
    {
        return await (from student in _context.Students
                join attendance in _context.Attendance on student.Id equals attendance.StudentId
                join lecture in _context.Lectures on attendance.LectureId equals lecture.LecturerId
                select new AttendanceRecord
                {
                    Name = student.Name,
                    Title = lecture.Title,
                    Date = lecture.Date,
                    Presence = attendance.Presence,
                    Assessment = attendance.Assessment
                })//.ProjectTo<AttendanceRecord>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<ExportAttendanceVm> Handle(ExportStudentAttendanceQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Students
            .Select(x=>x.Name)
            .ProjectTo<StudentRecord>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var vm = new ExportAttendanceVm(
            "Attendance.csv",
            "text/csv",
            _fileBuilder.BuildAttendanceFile(records));

        return vm;
    }
}*/