using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId
{

    [Authorize("user-read-access")]
    [Tags("Comments")]
    public class GetCommentsByTaskIdRestEndpoint : BaseApiController
    {
        public GetCommentsByTaskIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get comments for a task
        /// </summary>
        [HttpGet]
        [Route("tasks/{taskId}/comments")]
        public async Task<Result<IEnumerable<GetCommentDto>>> Get(string taskId)
        {
            return await _inMemoryBus.SendQuery(new GetCommentsByTaskIdRequest(taskId));
        }
    }

}