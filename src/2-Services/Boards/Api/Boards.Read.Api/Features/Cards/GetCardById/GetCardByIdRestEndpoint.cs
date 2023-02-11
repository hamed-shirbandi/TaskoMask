using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById
{

    [Authorize("user-read-access")]
    [Tags("Cards")]
    public class GetCardByIdRestEndpoint : BaseApiController
    {
        public GetCardByIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get card info
        /// </summary>
        [HttpGet]
        [Route("cards/{id}")]
        public async Task<Result<GetCardDto>> Get(string id)
        {
            return await _inMemoryBus.SendQuery(new GetCardByIdRequest(id));
        }
    }

}