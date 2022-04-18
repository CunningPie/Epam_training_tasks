using CleanArchitecture.Application.Lecturers.Queries;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lecturers.Queries;

using static Testing;

public class GetLecturersTests : TestBase
{
    [Test]
    public async Task ShouldReturnAllLecturers()
    {
        await AddAsync(new Lecturer()
        {
            Name = "Lecturer1",
            Email = "Email1"
        });
        
        await AddAsync(new Lecturer()
        {
            Name = "Lecturer2",
            Email = "Email2"
        });

        await AddAsync(new Lecturer()
        {
            Name = "Lecturer3",
            Email = "Email3"
        });
        
        var query = new GetLecturersQuery();

        var result = await SendAsync(query);

        result.Should().HaveCount(3);
    }
}