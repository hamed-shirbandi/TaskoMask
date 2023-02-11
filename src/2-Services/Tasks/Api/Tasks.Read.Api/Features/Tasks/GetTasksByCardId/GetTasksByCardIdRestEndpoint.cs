using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId
{

    [Authorize("user-read-access")]
    [Tags("Tasks")]
    public class GetTasksByCardIdRestEndpoint : BaseApiController
    {
        public GetTasksByCardIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get tasks for a card
        /// </summary>
        [HttpGet]
        [Route("cards/{cardId}/tasks")]
        public async Task<Result<IEnumerable<GetTaskDto>>> Get(string cardId)
        {
            return await _inMemoryBus.SendQuery(new GetTasksByCardIdRequest(cardId));
        }
    }

}