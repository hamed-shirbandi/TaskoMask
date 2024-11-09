using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.MoveTaskToAnotherCard;

[Authorize("user-write-access")]
[Tags("Tasks")]
public class MoveTaskToAnotherCardEndpoint : BaseApiController
{
    public MoveTaskToAnotherCardEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
        : base(authenticatedUserService, inMemoryBus) { }

    /// <summary>
    /// Move a task to another card
    /// </summary>
    [HttpPut]
    [Route("tasks/{taskId}/moveto/{cardId}")]
    public async Task<Result<CommandResult>> Put(string taskId, string cardId)
    {
        return await _inMemoryBus.SendCommand<MoveTaskToAnotherCardRequest>(new(taskId, cardId));
    }
}
