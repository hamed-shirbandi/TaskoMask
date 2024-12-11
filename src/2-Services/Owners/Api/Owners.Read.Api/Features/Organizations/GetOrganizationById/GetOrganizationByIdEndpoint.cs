using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationById;

[Authorize("user-read-access")]
[Tags("Organizations")]
public class GetOrganizationByIdEndpoint : BaseApiController
{
    public GetOrganizationByIdEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get organization basic info
    /// </summary>
    [HttpGet]
    [Route("organizations/{id}")]
    public async Task<Result<GetOrganizationDto>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetOrganizationByIdRequest(id));
    }
}
