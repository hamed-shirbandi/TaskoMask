using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.DeleteTask
{
    [Authorize("user-write-access")]
    [Tags("Tasks")]
    public class DeleteTaskEndpoint : BaseApiController
    {
        public DeleteTaskEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
            : base(authenticatedUserService, inMemoryBus) { }

        /// <summary>
        /// Delete an existing task
        /// </summary>
        [HttpDelete]
        [Route("tasks/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _inMemoryBus.SendCommand<DeleteTaskRequest>(new(id));
        }
    }
}
