using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.DeleteOrganization;

[Authorize("user-write-access")]
[Tags("Organizations")]
public class DeleteOrganizationEndpoint : BaseApiController
{
    public DeleteOrganizationEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Delete an organization
    /// </summary>
    [HttpDelete]
    [Route("organizations/{id}")]
    public async Task<Result<CommandResult>> Delete(string id)
    {
        return await _requestDispatcher.SendCommand<DeleteOrganizationRequest>(new(id));
    }
}
