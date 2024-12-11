using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.AddComment;

[Authorize("user-write-access")]
[Tags("Comments")]
public class AddCommentEndpoint : BaseApiController
{
    public AddCommentEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

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
