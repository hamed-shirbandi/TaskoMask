using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.UpdateCard
{

    [Authorize("user-write-access")]
    [Tags("Cards")]
    public class UpdateCardEndpoint : BaseApiController
    {
        public UpdateCardEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// Update an existing card
        /// </summary>
        [HttpPut]
        [Route("cards/{id}")]
        public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateCardDto input)
        {
            return await _inMemoryBus.SendCommand<UpdateCardRequest>(new(id: input.Id, name: input.Name, type: input.Type));
        }
    }

}