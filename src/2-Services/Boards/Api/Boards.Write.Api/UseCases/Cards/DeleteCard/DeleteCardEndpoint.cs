using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.DeleteCard
{

    [Authorize("user-write-access")]
    [Tags("Cards")]
    public class DeleteCardEndpoint : BaseApiController
    {
        public DeleteCardEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// Delete a card
        /// </summary>
        [HttpDelete]
        [Route("cards/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _inMemoryBus.SendCommand<DeleteCardRequest>(new(id));
        }
    }

}