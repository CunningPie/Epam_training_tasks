using CleanArchitecture.Application.Attendance.Queries.ExportAttendance;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IFileBuilder
{
    byte[] BuildAttendanceFile(IEnumerable<StudentRecord> records);
}