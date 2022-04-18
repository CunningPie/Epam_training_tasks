using CleanArchitecture.Application.Attendance.Queries.GetAttendance;
using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Attendance.Queries;

using static Testing;

public class GetAttendanceTests : TestBase
{
    private async Task SetUp()
    {
        var studentId1 = await SendAsync(new CreateStudentCommand {Name = "Student", Email = "Email", Phone = "Phone"});

        var studentId2 = await SendAsync(new CreateStudentCommand {Name = "Student2", Email = "Email2", Phone = "Phone2"});

        var studentId3 = await SendAsync(new CreateStudentCommand {Name = "Student3", Email = "Email3", Phone = "Phone3"});

        var homeworkId1 = await SendAsync(new CreateHomeworkCommand() {StudentId = studentId1});

        var homeworkId2 = await SendAsync(new CreateHomeworkCommand() {StudentId = studentId2});

        var lecturer1 = await SendAsync(new CreateLecturerCommand() {Name = "Name", Email = "Email"});

        var lecture1 = await SendAsync(new CreateLectureCommand() {LecturerId = lecturer1, Title = "Lecture", Date = DateTime.Now});

        await AddAsync(new LectureAttendance()
        {
            StudentId = studentId1,
            LectureId = lecture1,
            Assessment = 5,
            Presence = true,
            HomeworkId = homeworkId1
        });
        
        await AddAsync(new LectureAttendance()
        {
            StudentId = studentId2,
            LectureId = lecture1,
            Assessment = 5,
            Presence = true,
            HomeworkId = homeworkId2
        });
        
        await AddAsync(new LectureAttendance()
        {
            StudentId = studentId3,
            LectureId = lecture1,
            Assessment = 0,
            Presence = false
        });
    }
    
    [Test]
    public async Task ShouldReturnAllAttendance()
    {
        await SetUp();
        
        var query = new GetAttendanceQuery();

        var result = await SendAsync(query);

        result.Should().HaveCount(3);
    }
}