using CleanArchitecture.Application.Attendance.Commands.CreateAttendance;
using CleanArchitecture.Application.Attendance.Commands.UpdateAttendance;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Homeworks.Commands.UpdateHomework;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Attendance.Commands;

using static Testing;

public class UpdateLectureAttendanceTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidLectureAttendanceId()
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

        var command = new UpdateLectureAttendanceCommand { Id = 99, StudentId = studentId, LectureId = lectureId, HomeworkId = homeworkId, Assessment = 5, Presence = true};
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }
    
    [Test]
    public async Task ShouldUpdateLectureAttendance()
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
        
        var lectureAttendanceId = await SendAsync(new CreateLectureAttendanceCommand
        {
            Assessment = 5,
            Presence = true,
            LectureId = lectureId,
            StudentId = studentId,
            HomeworkId = homeworkId
        });
        
        var command = new UpdateLectureAttendanceCommand
        {
            Id = lectureAttendanceId,
            Assessment = 0,
            Presence = false,
            LectureId = lectureId,
            StudentId = studentId
        };
        
        await SendAsync(command);

        var lectureAttendance = await FindAsync<LectureAttendance>(lectureAttendanceId);

        lectureAttendance.Should().NotBeNull();
        lectureAttendance!.StudentId.Should().Be(command.StudentId);
        lectureAttendance!.LectureId.Should().Be(command.LectureId);
        lectureAttendance!.HomeworkId.Should().Be(command.HomeworkId);
        lectureAttendance!.Assessment.Should().Be(command.Assessment);
        lectureAttendance!.Presence.Should().Be(command.Presence);
    }
}