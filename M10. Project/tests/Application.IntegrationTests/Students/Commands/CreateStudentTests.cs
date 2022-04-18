using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Students.Commands;

using static Testing;

public class CreateStudentTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateStudentCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateStudent()
    {
        var command = new CreateStudentCommand
        {
            Name = "Student",
            Email = "Email",
            Phone = "Phone"
        };

        var studentId = await SendAsync(command);

        var student = await FindAsync<Student>(studentId);

        student.Should().NotBeNull();
        student!.Name.Should().Be(command.Name);
        student!.Email.Should().Be(command.Email);
        student!.Phone.Should().Be(command.Phone);
    }
}