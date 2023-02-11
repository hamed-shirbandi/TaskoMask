using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById
{

    [Authorize("user-read-access")]
    [Tags("Boards")]
    public class GetBoardByIdRestEndpoint : BaseApiController
    {
        public GetBoardByIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get board info
        /// </summary>
        [HttpGet]
        [Route("boards/{id}")]
        public async Task<Result<GetBoardDto>> Get(string id)
        {
            return await _inMemoryBus.SendQuery(new GetBoardByIdRequest(id));
        }
    }

}