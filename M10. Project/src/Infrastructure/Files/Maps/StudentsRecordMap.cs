using System.Globalization;
using CleanArchitecture.Application.Attendance.Queries.ExportAttendance;
using CsvHelper.Configuration;

namespace CleanArchitecture.Infrastructure.Files.Maps;

public class StudentRecordMap : ClassMap<StudentRecord>
{
    public StudentRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Name);
    }
}
