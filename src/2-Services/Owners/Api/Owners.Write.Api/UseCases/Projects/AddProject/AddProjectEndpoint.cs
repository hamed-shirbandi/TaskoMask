using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.AddProject;

[Authorize("user-write-access")]
[Tags("Projects")]
public class AddProjectEndpoint : BaseApiController
{
    public AddProjectEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Add new project
    /// </summary>
    [HttpPost]
    [Route("projects")]
    public async Task<Result<CommandResult>> Add([FromBody] AddProjectDto input)
    {
        return await _requestDispatcher.SendCommand<AddProjectRequest>(
            new(organizationId: input.OrganizationId, name: input.Name, description: input.Description)
        );
    }
}
