using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetBoardById;

[Authorize("user-read-access")]
[Tags("Boards")]
public class GetBoardByIdEndpoint : BaseApiController
{
    public GetBoardByIdEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get board detail information
    /// </summary>
    [HttpGet]
    [Route("boards/{id}")]
    public async Task<Result<BoardDetailsViewModel>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetBoardByIdRequest(id));
    }
}
