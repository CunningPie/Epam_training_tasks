using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lecturers.Commands.UpdateLecturer;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Application.Students.Commands.UpdateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lecturers.Commands;

using static Testing;

public class UpdateLecturersTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidLecturerId()
    {
        var command = new UpdateLecturerCommand { Id = 99, Name = "Name", Email = "Email"};
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateLecturer()
    {
        var lecturerId = await SendAsync(new CreateLecturerCommand
        {
            Name = "Name",
            Email = "Email"
        });

        var command = new UpdateLecturerCommand
        {
            Id = lecturerId,
            Name = "New Name",
            Email = "New Email"
        };

        await SendAsync(command);

        var lecturer = await FindAsync<Lecturer>(lecturerId);

        lecturer.Should().NotBeNull();
        lecturer!.Name.Should().Be(command.Name);
        lecturer!.Email.Should().Be(command.Email);
    }
}