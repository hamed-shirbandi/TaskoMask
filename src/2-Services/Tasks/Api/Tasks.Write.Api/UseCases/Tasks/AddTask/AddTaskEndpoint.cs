using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.AddTask;

[Authorize("user-write-access")]
[Tags("Tasks")]
public class AddTaskEndpoint : BaseApiController
{
    public AddTaskEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
        : base(authenticatedUserService, inMemoryBus) { }

    /// <summary>
    /// Add new task to board
    /// </summary>
    [HttpPost]
    [Route("tasks")]
    public async Task<Result<CommandResult>> Post([FromBody] AddTaskDto input)
    {
        return await _inMemoryBus.SendCommand<AddTaskRequest>(
            new(cardId: input.CardId, boardId: input.BoardId, title: input.Title, description: input.Description)
        );
    }
}
