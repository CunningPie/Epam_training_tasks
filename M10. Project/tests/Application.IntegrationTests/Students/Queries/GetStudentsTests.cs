using CleanArchitecture.Application.Students.Queries;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Students.Queries;

using static Testing;

public class GetStudentsTests : TestBase
{
    [Test]
    public async Task ShouldReturnAllStudents()
    {
        await AddAsync(new Student()
        {
            Name = "Student1",
            Email = "Email1",
            Phone = "Phone1",
        });
        
        await AddAsync(new Student()
        {
            Name = "Student2",
            Email = "Email2",
            Phone = "Phone2",
        });
        
        await AddAsync(new Student()
        {
            Name = "Student3",
            Email = "Email3",
            Phone = "Phone3",
        });

        var query = new GetStudentsQuery();

        var result = await SendAsync(query);

        result.Should().HaveCount(3);
    }
}