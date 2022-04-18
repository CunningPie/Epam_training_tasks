using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Application.Students.Commands.DeleteStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Students.Commands;

using static Testing;

public class DeleteStudentTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidStudentId()
    {
        var command = new DeleteStudentCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteStudent()
    {
        var studentId = await SendAsync(new CreateStudentCommand
        {
            Name = "Student",
            Email = "Email",
            Phone = "Phone"
        });

        await SendAsync(new DeleteStudentCommand
        {
            Id = studentId
        });

        var student = await FindAsync<Student>(studentId);

        student.Should().BeNull();
    }
}
