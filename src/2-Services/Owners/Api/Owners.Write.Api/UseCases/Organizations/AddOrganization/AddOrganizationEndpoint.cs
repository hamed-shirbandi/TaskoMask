using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.AddOrganization;

[Authorize("user-write-access")]
[Tags("Organizations")]
public class AddOrganizationEndpoint : BaseApiController
{
    public AddOrganizationEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Add new organization for current owner
    /// </summary>
    [HttpPost]
    [Route("organizations")]
    public async Task<Result<CommandResult>> Post([FromBody] AddOrganizationDto input)
    {
        input.OwnerId = GetCurrentUserId();
        return await _requestDispatcher.SendCommand<AddOrganizationRequest>(
            new(ownerId: input.OwnerId, name: input.Name, description: input.Description)
        );
    }
}
