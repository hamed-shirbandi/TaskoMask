using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.UpdateOrganization;

[Authorize("user-write-access")]
[Tags("Organizations")]
public class UpdateOrganizationEndpoint : BaseApiController
{
    public UpdateOrganizationEndpoint(IAuthenticatedUserService authenticatedUserService, IRequestDispatcher requestDispatcher)
        : base(authenticatedUserService, requestDispatcher) { }

    /// <summary>
    /// Update an existing organization
    /// </summary>
    [HttpPut]
    [Route("organizations/{id}")]
    public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateOrganizationDto input)
    {
        return await _requestDispatcher.SendCommand<UpdateOrganizationRequest>(new(id: id, name: input.Name, description: input.Description));
    }
}
