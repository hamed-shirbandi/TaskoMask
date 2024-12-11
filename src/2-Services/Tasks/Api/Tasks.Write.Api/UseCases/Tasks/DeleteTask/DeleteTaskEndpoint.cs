using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.DeleteTask;

[Authorize("user-write-access")]
[Tags("Tasks")]
public class DeleteTaskEndpoint : BaseApiController
{
    public DeleteTaskEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Delete an existing task
    /// </summary>
    [HttpDelete]
    [Route("tasks/{id}")]
    public async Task<Result<CommandResult>> Delete(string id)
    {
        return await _requestDispatcher.SendCommand<DeleteTaskRequest>(new(id));
    }
}
