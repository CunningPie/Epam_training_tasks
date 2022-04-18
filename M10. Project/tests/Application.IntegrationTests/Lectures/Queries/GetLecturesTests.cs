using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lectures.Queries;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Lectures.Commands;

using static Testing;

public class GetLecturesTests : TestBase
{
    [Test]
    public async Task ShouldReturnAllLectures()
    {
        var lectureId =  await SendAsync(new CreateLecturerCommand
        {
            Name = "Lecturer",
            Email = "Email"
        });

        await AddAsync(new Lecture()
        {
            Title = "Lecture1",
            Date = DateTime.Now,
            LecturerId = lectureId 
        });
        
        await AddAsync(new Lecture()
        {
            Title = "Lecture2",
            Date = DateTime.Now,
            LecturerId = lectureId 
        });
        
        await AddAsync(new Lecture()
        {
            Title = "Lecture3",
            Date = DateTime.Now,
            LecturerId = lectureId 
        });

        var query = new GetLecturesQuery();

        var result = await SendAsync(query);

        result.Should().HaveCount(3);
    }
}