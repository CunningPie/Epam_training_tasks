using CleanArchitecture.Application.Attendance.Commands.CreateAttendance;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Attendance.Commands;

using static Testing;

public class CreateLectureAttendanceTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateLectureAttendanceCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateLectureAttendance()
    {
        var studentId = await SendAsync(new CreateStudentCommand
        {
            Name = "Student",
            Email = "Email",
            Phone = "Phone"
        });
        
        var homeworkId = await SendAsync(new CreateHomeworkCommand
        {
            StudentId = studentId
        });
        
        var lecturerId = await SendAsync(new CreateLecturerCommand
        {
            Name = "Lecturer",
            Email = "Email"
        });
        
        var lectureId = await SendAsync(new CreateLectureCommand
        {
            Title = "Title",
            Date = DateTime.Now,
            LecturerId = lecturerId
        });
        
        var command = new CreateLectureAttendanceCommand
        {
            Assessment = 5,
            Presence = true,
            LectureId = lectureId,
            StudentId = studentId,
            HomeworkId = homeworkId
        };

        var attendanceId = await SendAsync(command);

        var lectureAttendance = await FindAsync<LectureAttendance>(attendanceId);

        lectureAttendance.Should().NotBeNull();
        lectureAttendance!.StudentId.Should().Be(command.StudentId);
        lectureAttendance!.Assessment.Should().Be(command.Assessment);
        lectureAttendance!.LectureId.Should().Be(command.LectureId);
        lectureAttendance!.Presence.Should().Be(command.Presence);
        lectureAttendance!.HomeworkId.Should().Be(command.HomeworkId);
    }
}