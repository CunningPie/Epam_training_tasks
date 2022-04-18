using CleanArchitecture.Application.Homeworks.Queries;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Homeworks.Queries;

using static Testing;

public class GetHomeworksTests : TestBase
{
    [Test]
    public async Task ShouldReturnAllHomeworks()
    {
        var studentId =  await SendAsync(new CreateStudentCommand
        {
            Name = "Student",
            Email = "Email",
            Phone = "Phone"
        });

        await AddAsync(new Homework()
        {
            StudentId = studentId
        });
        
        await AddAsync(new Homework()
        {
            StudentId = studentId
        });

        await AddAsync(new Homework()
        {
            StudentId = studentId
        });
        
        var query = new GetHomeworksQuery();

        var result = await SendAsync(query);

        result.Should().HaveCount(3);
    }
}