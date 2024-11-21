using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;

[Authorize("user-read-access")]
[Tags("Tasks")]
public class GetTaskByIdRestEndpoint : BaseApiController
{
    public GetTaskByIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IRequestDispatcher requestDispatcher)
        : base(authenticatedUserService, requestDispatcher) { }

    /// <summary>
    /// get task info
    /// </summary>
    [HttpGet]
    [Route("tasks/{id}")]
    public async Task<Result<GetTaskDto>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetTaskByIdRequest(id));
    }
}
