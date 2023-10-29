using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.UpdateProject
{
    [Authorize("user-write-access")]
    [Tags("Projects")]
    public class UpdateProjectEndpoint : BaseApiController
    {
        public UpdateProjectEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
            : base(authenticatedUserService, inMemoryBus) { }

        /// <summary>
        /// Update an existing project
        /// </summary>
        [HttpPut]
        [Route("projects/{id}")]
        public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateProjectDto input)
        {
            return await _inMemoryBus.SendCommand<UpdateProjectRequest>(new(id: input.Id, name: input.Name, description: input.Description));
        }
    }
}
