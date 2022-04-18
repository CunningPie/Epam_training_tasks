namespace CleanArchitecture.Application.Attendance.Queries.ExportAttendance;

public class ExportStudentsVm
{
    public ExportStudentsVm(string fileName, string contentType, byte[] content)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = content;
    }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public byte[] Content { get; set; }
}
