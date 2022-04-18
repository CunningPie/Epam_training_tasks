using CleanArchitecture.Application.Lecturers.Commands.CreateLecturer;
using CleanArchitecture.Application.Lecturers.Commands.DeleteLecturer;
using CleanArchitecture.Application.Lecturers.Commands.UpdateLecturer;
using CleanArchitecture.Application.Lecturers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

/// <summary>
/// Контроллер для лекторов таблицы Lecturers.
/// </summary>
public class LecturersController : ApiControllerBase
{
    /// <summary>
    /// HttpGet запрос на получение полного списка лекторов из таблицы Lecturers.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IList<LecturerDto>> GetLecturers(
        [FromQuery] GetLecturersQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// HttpPost запрос на создание лектора.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateLecturerCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// HttpPut запрос на обновление лектора.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateLecturerCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// HttpDelete запрос на удаление лектора.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteLecturerCommand {Id = id});

        return NoContent();
    }
}