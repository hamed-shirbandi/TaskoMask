using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
    public AddCommentEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
        : base(authenticatedUserService, inMemoryBus) { }

    /// <summary>
    /// Add new comment to task
    /// </summary>
    [HttpPost]
    [Route("comments")]
    public async Task<Result<CommandResult>> Post([FromBody] AddCommentDto input)
    {
        return await _inMemoryBus.SendCommand<AddCommentRequest>(new(input.TaskId, input.Content));
    }
}
