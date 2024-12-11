using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId;

[Authorize("user-read-access")]
[Tags("Comments")]
public class GetCommentsByTaskIdRestEndpoint : BaseApiController
{
    public GetCommentsByTaskIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get comments for a task
    /// </summary>
    [HttpGet]
    [Route("tasks/{taskId}/comments")]
    public async Task<Result<IEnumerable<GetCommentDto>>> Get(string taskId)
    {
        return await _requestDispatcher.SendQuery(new GetCommentsByTaskIdRequest(taskId));
    }
}
