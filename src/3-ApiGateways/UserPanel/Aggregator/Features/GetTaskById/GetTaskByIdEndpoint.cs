using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetTaskById;

[Authorize("user-read-access")]
[Tags("Tasks")]
public class GetTaskByIdEndpoint : BaseApiController
{
    public GetTaskByIdEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get task detail information
    /// </summary>
    [HttpGet]
    [Route("tasks/{id}")]
    public async Task<Result<TaskDetailsViewModel>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetTaskByIdRequest(id));
    }
}
