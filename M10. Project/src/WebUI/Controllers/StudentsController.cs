using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Application.Students.Commands.DeleteStudent;
using CleanArchitecture.Application.Students.Commands.UpdateStudent;
using CleanArchitecture.Application.Students.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

/// <summary>
/// Контроллер для студентов таблицы Students.
/// </summary>
public class StudentsController : ApiControllerBase
{
    /// <summary>
    /// HttpGet запрос на получение полного списка студентов из таблицы Students.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IList<StudentDto>> GetStudents(
        [FromQuery] GetStudentsQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// HttpPost запрос на создание студента.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateStudentCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// HttpPut запрос на обновление студента.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateStudentCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// HttpDelete запрос на удаление студента.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteStudentCommand {Id = id});

        return NoContent();
    }
}