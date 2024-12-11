using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId;

[Authorize("user-read-access")]
[Tags("Organizations")]
public class GetOrganizationsByOwnerIdRestEndpoint : BaseApiController
{
    public GetOrganizationsByOwnerIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get organizations for current owner
    /// </summary>
    [HttpGet]
    [Route("organizations")]
    public async Task<Result<IEnumerable<GetOrganizationDto>>> Get()
    {
        return await _requestDispatcher.SendQuery(new GetOrganizationsByOwnerIdRequest(GetCurrentUserId()));
    }
}
