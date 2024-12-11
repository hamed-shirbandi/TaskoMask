using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById;

[Authorize("user-read-access")]
[Tags("Projects")]
public class GetProjectByIdRestEndpoint : BaseApiController
{
    public GetProjectByIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get project basic info
    /// </summary>
    [HttpGet]
    [Route("projects/{id}")]
    public async Task<Result<GetProjectDto>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetProjectByIdRequest(id));
    }
}
