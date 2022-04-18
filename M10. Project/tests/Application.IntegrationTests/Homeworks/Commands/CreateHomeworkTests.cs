using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Homeworks.Commands;

using static Testing;

public class CreateHomeworkTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateHomeworkCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Test]
    public async Task ShouldCreateHomework()
    {
        var studentId = await SendAsync(new CreateStudentCommand
        {
            Name = "Student",
            Email = "Email",
            Phone = "Phone"
        });
        
        var command = new CreateHomeworkCommand
        {
            StudentId = studentId
        };

        var homeworkId = await SendAsync(command);

        var homework = await FindAsync<Homework>(homeworkId);

        homework.Should().NotBeNull();
        homework!.StudentId.Should().Be(command.StudentId);
    }
}