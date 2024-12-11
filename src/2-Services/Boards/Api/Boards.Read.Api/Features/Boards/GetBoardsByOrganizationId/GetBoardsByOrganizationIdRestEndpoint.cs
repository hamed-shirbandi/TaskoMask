using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByOrganizationId;

[Authorize("user-read-access")]
[Tags("Boards")]
public class GetBoardsByOrganizationIdRestEndpoint : BaseApiController
{
    public GetBoardsByOrganizationIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get boards for an organization
    /// </summary>
    [HttpGet]
    [Route("organizations/{organizationId}/boards")]
    public async Task<Result<IEnumerable<GetBoardDto>>> Get(string organizationId)
    {
        return await _requestDispatcher.SendQuery(new GetBoardsByOrganizationIdRequest(organizationId));
    }
}
