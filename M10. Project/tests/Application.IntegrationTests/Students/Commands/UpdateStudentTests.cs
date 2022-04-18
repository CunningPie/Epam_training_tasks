using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Application.Students.Commands.UpdateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Students.Commands;

using static Testing;

public class UpdateStudentsTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidStudentId()
    {
        var command = new UpdateStudentCommand { Id = 99, Name = "Name", Email = "Email", Phone = "Phone" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateStudent()
    {
        var studentId = await SendAsync(new CreateStudentCommand
        {
            Name = "Name",
            Email = "Email",
            Phone = "Phone"
        });

        var command = new UpdateStudentCommand
        {
            Id = studentId,
            Name = "New Name",
            Email = "New Email",
            Phone = "New Phone"
        };

        await SendAsync(command);

        var student = await FindAsync<Student>(studentId);

        student.Should().NotBeNull();
        student!.Name.Should().Be(command.Name);
        student!.Email.Should().Be(command.Email);
        student!.Phone.Should().Be(command.Phone);
    }
}
