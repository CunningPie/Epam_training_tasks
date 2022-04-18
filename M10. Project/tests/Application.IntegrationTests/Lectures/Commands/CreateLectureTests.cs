using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lectures.Commands;

using static Testing;

public class CreateLectureTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateLectureCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateLecture()
    {
        var lecturerId = await SendAsync(new CreateLecturerCommand
        {
            Name = "Name",
            Email = "Email"
        });

        var command = new CreateLectureCommand
        {
            LecturerId = lecturerId,
            Title = "Lecture",
            Date = DateTime.Now
        };

        var lectureId = await SendAsync(command);

        var lecture = await FindAsync<Lecture>(lectureId);

        lecture.Should().NotBeNull();
        lecture!.LecturerId.Should().Be(command.LecturerId);
        lecture!.Title.Should().Be(command.Title);
        lecture!.Date.Should().Be(command.Date);
    }
}