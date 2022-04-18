using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lecturers.Commands.DeleteLecturer;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lecturers.Commands;

using static Testing;

public class DeleteLecturerTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidLecturerId()
    {
        var command = new DeleteLecturerCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteLecturer()
    {
        var lecturerId = await SendAsync(new CreateLecturerCommand
        {
            Name = "Lecturer",
            Email = "Email"
        });

        await SendAsync(new DeleteLecturerCommand
        {
            Id = lecturerId
        });

        var lecturer = await FindAsync<Lecturer>(lecturerId);

        lecturer.Should().BeNull();
    }
}