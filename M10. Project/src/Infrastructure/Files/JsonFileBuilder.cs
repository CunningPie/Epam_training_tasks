using System.Globalization;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Attendance.Queries.ExportAttendance;
using CleanArchitecture.Infrastructure.Files.Maps;
using CsvHelper;

namespace CleanArchitecture.Infrastructure.Files;

public class JsonFileBuilder : IFileBuilder
{
    public byte[] BuildAttendanceFile(IEnumerable<StudentRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<StudentRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
    
}