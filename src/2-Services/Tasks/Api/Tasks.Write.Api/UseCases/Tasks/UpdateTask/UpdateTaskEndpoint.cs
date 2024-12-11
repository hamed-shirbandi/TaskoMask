using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.UpdateTask;

[Authorize("user-write-access")]
[Tags("Tasks")]
public class UpdateTaskEndpoint : BaseApiController
{
    public UpdateTaskEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Update an existing task
    /// </summary>
    [HttpPut]
    [Route("tasks/{id}")]
    public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateTaskDto input)
    {
        return await _requestDispatcher.SendCommand<UpdateTaskRequest>(new(id: id, title: input.Title, description: input.Description));
    }
}
