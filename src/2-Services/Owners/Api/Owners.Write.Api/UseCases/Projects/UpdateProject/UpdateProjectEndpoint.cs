using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.UpdateProject;

[Authorize("user-write-access")]
[Tags("Projects")]
public class UpdateProjectEndpoint : BaseApiController
{
    public UpdateProjectEndpoint(IAuthenticatedUserService authenticatedUserService, IRequestDispatcher requestDispatcher)
        : base(authenticatedUserService, requestDispatcher) { }

    /// <summary>
    /// Update an existing project
    /// </summary>
    [HttpPut]
    [Route("projects/{id}")]
    public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateProjectDto input)
    {
        return await _requestDispatcher.SendCommand<UpdateProjectRequest>(new(id: id, name: input.Name, description: input.Description));
    }
}
