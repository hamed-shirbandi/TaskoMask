using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Owners.GetOwnerById;

[Authorize("user-read-access")]
[Tags("Owners")]
public class GetOwnerByIdEndpoint : BaseApiController
{
    public GetOwnerByIdEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get current owner basic information
    /// </summary>
    [HttpGet]
    [Route("owner")]
    public async Task<Result<GetOwnerDto>> Get()
    {
        return await _requestDispatcher.SendQuery(new GetOwnerByIdRequest(GetCurrentUserId()));
    }
}
