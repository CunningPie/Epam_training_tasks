using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Homeworks.Commands.UpdateHomework;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Homeworks.Commands;

using static Testing;

public class UpdateHomeworkTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidHomeworkId()
    {
        var studentId = await SendAsync(new CreateStudentCommand
        {
            Name = "Student",
            Email = "Email",
            Phone = "Phone"
        });
        
        var command = new UpdateHomeworkCommand { Id = 99, StudentId = studentId};
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }
    
    [Test]
    public async Task ShouldUpdateHomework()
    {
        var studentId = await SendAsync(new CreateStudentCommand
        {
            Name = "Student",
            Email = "Email",
            Phone = "Phone"
        });

        var homeworkId = await SendAsync(new CreateHomeworkCommand
        {
            StudentId = studentId,
        });

        var command = new UpdateHomeworkCommand
        {
            Id = homeworkId,
            StudentId = studentId,
        };

        await SendAsync(command);

        var homework = await FindAsync<Homework>(homeworkId);

        homework.Should().NotBeNull();
        homework!.StudentId.Should().Be(command.StudentId);
    }
}