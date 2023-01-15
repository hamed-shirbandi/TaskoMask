using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentById
{

    [Authorize("user-read-access")]
    [Tags("Comments")]
    public class GetCommentByIdRestEndpoint : BaseApiController
    {
        public GetCommentByIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get comment info
        /// </summary>
        [HttpGet]
        [Route("comments/{id}")]
        public async Task<Result<GetCommentDto>> Get(string id)
        {
            return await _inMemoryBus.SendQuery(new GetCommentByIdRequest(id));
        }
    }

}