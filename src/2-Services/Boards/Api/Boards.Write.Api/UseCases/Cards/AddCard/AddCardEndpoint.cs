using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.AddCard
{
    [Authorize("user-write-access")]
    [Tags("Cards")]
    public class AddCardEndpoint : BaseApiController
    {
        public AddCardEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
            : base(authenticatedUserService, inMemoryBus) { }

        /// <summary>
        /// Add new card
        /// </summary>
        [HttpPost]
        [Route("cards")]
        public async Task<Result<CommandResult>> Add([FromBody] AddCardDto input)
        {
            return await _inMemoryBus.SendCommand<AddCardRequest>(new(boardId: input.BoardId, name: input.Name, type: input.Type));
        }
    }
}
