using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.UpdateComment;

[Authorize("user-write-access")]
[Tags("Comments")]
public class UpdateCommentEndpoint : BaseApiController
{
    public UpdateCommentEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Update an existing comment
    /// </summary>
    [HttpPut]
    [Route("comments")]
    public async Task<Result<CommandResult>> Put([FromBody] UpdateCommentDto input)
    {
        return await _requestDispatcher.SendCommand<UpdateCommentRequest>(new(input.Id, input.Content));
    }
}
