using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Homeworks.Commands.DeleteHomework;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Homeworks.Commands;

using static Testing;

public class DeleteHomeworkTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidHomeworkId()
    {
        var command = new DeleteHomeworkCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteHomework()
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

        await SendAsync(new DeleteHomeworkCommand
        {
            Id = homeworkId
        });

        var homework = await FindAsync<Homework>(homeworkId);

        homework.Should().BeNull();
    }
}