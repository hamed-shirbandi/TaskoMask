using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.AddBoard
{

    [Authorize("user-write-access")]
    [Tags("Boards")]
    public class AddBoardEndpoint : BaseApiController
    {
        public AddBoardEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// Add new board
        /// </summary>
        [HttpPost]
        [Route("boards")]
        public async Task<Result<CommandResult>> Post([FromBody] AddBoardDto input)
        {
            return await _inMemoryBus.SendCommand<AddBoardRequest>(new(projectId: input.ProjectId, name: input.Name, description: input.Description));
        }
    }

}