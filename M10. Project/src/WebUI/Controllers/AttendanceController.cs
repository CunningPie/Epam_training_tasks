using CleanArchitecture.Application.Attendance.Commands.CreateAttendance;
using CleanArchitecture.Application.Attendance.Commands.DeleteAttendance;
using CleanArchitecture.Application.Attendance.Commands.UpdateAttendance;
using CleanArchitecture.Application.Attendance.Queries.ExportAttendance;
using CleanArchitecture.Application.Attendance.Queries.GetAttendance;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

/// <summary>
/// Контроллер для посещаемости таблицы Attendance.
/// </summary>
public class AttendanceController : ApiControllerBase
{
    /// <summary>
    /// HttpGet запрос на получение полного списка посещаемости из таблицы Attendance.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IList<AttendanceDto>> GetAttendance(
        [FromQuery] GetAttendanceQuery query)
    {
        return await Mediator.Send(query);
    }
    /*
    [HttpGet]
    public async Task<FileResult> Get()
    {
        var vm = await Mediator.Send(new ExportAttendanceQuery());

        return File(vm.Content, vm.ContentType, vm.FileName);
    }*/

    /// <summary>
    /// HttpPost запрос на создание записи посещаемости.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateLectureAttendanceCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// HttpPut запрос на обновление записи посещаемости.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateLectureAttendanceCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// HttpDelete запрос на удаление записи посещения.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteLectureAttendanceCommand {Id = id});

        return NoContent();
    }
}