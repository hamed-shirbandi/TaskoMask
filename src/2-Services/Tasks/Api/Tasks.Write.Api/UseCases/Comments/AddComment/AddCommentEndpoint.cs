using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.AddComment;

[Authorize("user-write-access")]
[Tags("Comments")]
public class AddCommentEndpoint : BaseApiController
{
    public AddCommentEndpoint(IAuthenticatedUserService authenticatedUserService, IRequestDispatcher requestDispatcher)
        : base(authenticatedUserService, requestDispatcher) { }

    /// <summary>
    /// Add new comment to task
    /// </summary>
    [HttpPost]
    [Route("comments")]
    public async Task<Result<CommandResult>> Post([FromBody] AddCommentDto input)
    {
        return await _requestDispatcher.SendCommand<AddCommentRequest>(new(input.TaskId, input.Content));
    }
}
