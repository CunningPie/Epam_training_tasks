using CleanArchitecture.Application.Attendance.Commands.CreateAttendance;
using CleanArchitecture.Application.Attendance.Commands.DeleteAttendance;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Homeworks.Commands.DeleteHomework;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Attendance.Commands;

using static Testing;

public class DeleteLectureAttendanceTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidLectureAttendanceId()
    {
        var command = new DeleteLectureAttendanceCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteLectureAttendance()
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
        
        var attendanceId = await SendAsync( new CreateLectureAttendanceCommand
        {
            Assessment = 5,
            Presence = true,
            LectureId = lectureId,
            StudentId = studentId,
            HomeworkId = homeworkId
        });

        await SendAsync(new DeleteLectureAttendanceCommand
        {
            Id = attendanceId
        });

        var lectureAttendance = await FindAsync<LectureAttendance>(attendanceId);

        lectureAttendance.Should().BeNull();
    }
}