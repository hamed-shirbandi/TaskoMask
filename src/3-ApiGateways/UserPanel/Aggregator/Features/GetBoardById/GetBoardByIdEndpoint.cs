using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetBoardById
{

    [Authorize("user-read-access")]
    [Tags("Boards")]
    public class GetBoardByIdEndpoint : BaseApiController
    {
        public GetBoardByIdEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get board detail information
        /// </summary>
        [HttpGet]
        [Route("boards/{id}")]
        public async Task<Result<BoardDetailsViewModel>> Get(string id)
        {
            return await _inMemoryBus.SendQuery(new GetBoardByIdRequest(id));
        }
    }

}