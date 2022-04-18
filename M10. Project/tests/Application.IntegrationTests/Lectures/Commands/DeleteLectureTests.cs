using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Application.Lectures.Commands.DeleteLecture;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lectures.Commands;

using static Testing;

public class DeleteLectureTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidLectureId()
    {
        var command = new DeleteLectureCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteLecture()
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

        await SendAsync(new DeleteLectureCommand
        {
            Id = lectureId
        });

        var lecture = await FindAsync<Lecture>(lectureId);

        lecture.Should().BeNull();
    }
}
