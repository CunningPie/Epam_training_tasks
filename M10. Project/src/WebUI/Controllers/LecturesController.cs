using CleanArchitecture.Application.Lectures.Commands.CreateLecture;
using CleanArchitecture.Application.Lectures.Commands.DeleteLecture;
using CleanArchitecture.Application.Lectures.Commands.UpdateLecture;
using CleanArchitecture.Application.Lectures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

/// <summary>
/// Контроллер для лекций таблицы Lectures.
/// </summary>
public class LecturesController : ApiControllerBase
{
    /// <summary>
    /// HttpGet запрос на получение полного списка лекций из таблицы Lectures.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IList<LectureDto>> GetLectures(
        [FromQuery] GetLecturesQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// HttpPost запрос на создание лекции.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateLectureCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// HttpPut запрос на обновление лекции.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateLectureCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// HttpDelete запрос на удаление лекции.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteLectureCommand {Id = id});

        return NoContent();
    }
}