using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId
{

    [Authorize("user-read-access")]
    [Tags("Cards")]
    public class GetCardsByBoardIdRestEndpoint : BaseApiController
    {
        public GetCardsByBoardIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get card info
        /// </summary>
        [HttpGet]
        [Route("cards/{id}")]
        [Route("boards/{boardId}/cards")]
        public async Task<Result<IEnumerable<GetCardDto>>> Get(string boardId)
        {
            return await _inMemoryBus.SendQuery(new GetCardsByBoardIdRequest(boardId));
        }
    }

}