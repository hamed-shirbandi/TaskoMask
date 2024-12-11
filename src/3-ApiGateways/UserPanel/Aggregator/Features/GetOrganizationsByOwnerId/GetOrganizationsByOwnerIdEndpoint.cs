using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetOrganizationsByOwnerId;

[Authorize("user-read-access")]
[Tags("Organizations")]
public class GetOrganizationsByOwnerIdEndpoint : BaseApiController
{
    public GetOrganizationsByOwnerIdEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get organizations with detail information for current owner
    /// </summary>
    [HttpGet]
    [Route("organizations")]
    public async Task<Result<IEnumerable<OrganizationDetailsViewModel>>> Get()
    {
        return await _requestDispatcher.SendQuery(new GetOrganizationsByOwnerIdRequest(GetCurrentUserId()));
    }
}
