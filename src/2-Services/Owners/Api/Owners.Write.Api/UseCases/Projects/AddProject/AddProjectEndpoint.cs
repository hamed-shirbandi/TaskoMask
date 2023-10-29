using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.AddProject;

[Authorize("user-write-access")]
[Tags("Projects")]
public class AddProjectEndpoint : BaseApiController
{
    public AddProjectEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
        : base(authenticatedUserService, inMemoryBus) { }

    /// <summary>
    /// Add new project
    /// </summary>
    [HttpPost]
    [Route("projects")]
    public async Task<Result<CommandResult>> Add([FromBody] AddProjectDto input)
    {
        return await _inMemoryBus.SendCommand<AddProjectRequest>(
            new(organizationId: input.OrganizationId, name: input.Name, description: input.Description)
        );
    }
}
