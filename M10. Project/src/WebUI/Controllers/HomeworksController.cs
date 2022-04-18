using CleanArchitecture.Application.Homeworks.Commands.CreateHomework;
using CleanArchitecture.Application.Homeworks.Commands.DeleteHomework;
using CleanArchitecture.Application.Homeworks.Commands.UpdateHomework;
using CleanArchitecture.Application.Homeworks.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

/// <summary>
/// Контроллер для домашней работы таблицы Homeworks.
/// </summary>
public class HomeworksController : ApiControllerBase
{
    /// <summary>
    /// HttpGet запрос на получение полного списка домашней работы из таблицы Homeworks.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IList<HomeworkDto>> GetHomeworks(
        [FromQuery] GetHomeworksQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// HttpPost запрос на создание домашней работы.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateHomeworkCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// HttpPut запрос на обновление домашней работы.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateHomeworkCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// HttpDelete запрос на удаление домашней работы.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteHomeworkCommand {Id = id});

        return NoContent();
    }
}