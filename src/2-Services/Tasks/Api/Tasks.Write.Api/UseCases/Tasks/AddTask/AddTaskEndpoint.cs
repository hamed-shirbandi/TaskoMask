using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.AddTask;

[Authorize("user-write-access")]
[Tags("Tasks")]
public class AddTaskEndpoint : BaseApiController
{
    public AddTaskEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Add new task to board
    /// </summary>
    [HttpPost]
    [Route("tasks")]
    public async Task<Result<CommandResult>> Post([FromBody] AddTaskDto input)
    {
        return await _requestDispatcher.SendCommand<AddTaskRequest>(
            new(cardId: input.CardId, boardId: input.BoardId, title: input.Title, description: input.Description)
        );
    }
}
