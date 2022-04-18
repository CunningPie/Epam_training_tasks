using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lecturers.Commands;

using static Testing;

public class CreateLecturerTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateLecturerCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateLecture()
    {
        var command = new CreateLecturerCommand
        {
            Name = "Lecturer",
            Email = "Email"
        };

        var lecturerId = await SendAsync(command);

        var lecturer = await FindAsync<Lecturer>(lecturerId);

        lecturer.Should().NotBeNull();
        lecturer!.Name.Should().Be(command.Name);
    }
}