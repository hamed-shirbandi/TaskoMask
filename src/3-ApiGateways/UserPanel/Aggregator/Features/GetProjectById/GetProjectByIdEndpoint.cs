using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetProjectById;

[Authorize("user-read-access")]
[Tags("Projects")]
public class GetProjectByIdEndpoint : BaseApiController
{
    public GetProjectByIdEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get project detail information
    /// </summary>
    [HttpGet]
    [Route("projects/{id}")]
    public async Task<Result<ProjectDetailsViewModel>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetProjectByIdRequest(id));
    }
}
