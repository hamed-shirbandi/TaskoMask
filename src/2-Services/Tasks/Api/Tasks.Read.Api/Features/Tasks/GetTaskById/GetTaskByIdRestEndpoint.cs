using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;

[Authorize("user-read-access")]
[Tags("Tasks")]
public class GetTaskByIdRestEndpoint : BaseApiController
{
    public GetTaskByIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

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
