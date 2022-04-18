namespace CleanArchitecture.Application.Attendance.Queries.ExportAttendance;

public class ExportAttendanceVm
{
    public ExportAttendanceVm(string fileName, string contentType, byte[] content)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = content;
    }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public byte[] Content { get; set; }
}