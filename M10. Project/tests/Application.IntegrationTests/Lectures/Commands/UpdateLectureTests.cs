using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Application.Lectures.Commands.UpdateLecture;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lectures.Commands;

using static Testing;

public class UpdateLectureTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidLecturetId()
    {
        var command = new UpdateLectureCommand { Id = 99, LecturerId = 99, Title = "Title", Date = DateTime.Now };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateLecture()
    {
        var lecturerId = await SendAsync(new CreateLecturerCommand
        {
            Name = "Name",
            Email = "Email"
        });

        var lectureId = await SendAsync(new CreateLectureCommand
        {
            LecturerId = lecturerId,
            Title = "Title",
            Date = DateTime.Now
        });

        var command = new UpdateLectureCommand
        {
            Id = lectureId,
            LecturerId = lecturerId,
            Title= "New Title",
            Date = DateTime.Now
        };

        await SendAsync(command);

        var lecture = await FindAsync<Lecture>(lectureId);

        lecture.Should().NotBeNull();
        lecture!.LecturerId.Should().Be(command.LecturerId);
        lecture!.Title.Should().Be(command.Title);
        lecture!.Date.Should().Be(command.Date);
    }
}
