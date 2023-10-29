using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.UpdateTask;

[Authorize("user-write-access")]
[Tags("Tasks")]
public class UpdateTaskEndpoint : BaseApiController
{
    public UpdateTaskEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
        : base(authenticatedUserService, inMemoryBus) { }

    /// <summary>
    /// Update an existing task
    /// </summary>
    [HttpPut]
    [Route("tasks/{id}")]
    public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateTaskDto input)
    {
        return await _inMemoryBus.SendCommand<UpdateTaskRequest>(new(id: input.Id, title: input.Title, description: input.Description));
    }
}
