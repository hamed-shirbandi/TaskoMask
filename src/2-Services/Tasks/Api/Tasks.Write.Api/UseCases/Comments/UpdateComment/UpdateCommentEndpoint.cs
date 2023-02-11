using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.UpdateComment
{

    [Authorize("user-write-access")]
    [Tags("Comments")]
    public class UpdateCommentEndpoint : BaseApiController
    {
        public UpdateCommentEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// Update an existing comment
        /// </summary>
        [HttpPut]
        [Route("comments")]
        public async Task<Result<CommandResult>> Put([FromBody] UpdateCommentDto input)
        {
            return await _inMemoryBus.SendCommand<UpdateCommentRequest>(new(input.Id, input.Content));
        }
    }

}