using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId;

[Authorize("user-read-access")]
[Tags("Tasks")]
public class GetTasksByCardIdRestEndpoint : BaseApiController
{
    public GetTasksByCardIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IRequestDispatcher requestDispatcher)
        : base(authenticatedUserService, requestDispatcher) { }

    /// <summary>
    /// get tasks for a card
    /// </summary>
    [HttpGet]
    [Route("cards/{cardId}/tasks")]
    public async Task<Result<IEnumerable<GetTaskDto>>> Get(string cardId)
    {
        return await _requestDispatcher.SendQuery(new GetTasksByCardIdRequest(cardId));
    }
}
