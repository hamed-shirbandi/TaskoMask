using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.AddBoard;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.UpdateBoard;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.DeleteBoard;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.Services.Boards.Write.Api.Controllers
{
    [Authorize("user-write-access")]
    public class BoardsController : BaseApiController
    {
        #region Fields


        #endregion

        #region Ctors

        public BoardsController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// Add new board
        /// </summary>
        [HttpPost]
        [Route("boards")]
        public async Task<Result<CommandResult>> Add([FromBody] AddBoardDto input)
        {
            return await _inMemoryBus.SendCommand<AddBoardRequest>(new(projectId: input.ProjectId, name: input.Name, description: input.Description));
        }



        /// <summary>
        /// Update an existing board
        /// </summary>
        [HttpPut]
        [Route("boards/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] UpdateBoardDto input)
        {
            return await _inMemoryBus.SendCommand<UpdateBoardRequest>(new(id: input.Id, name: input.Name, description: input.Description));
        }



        /// <summary>
        /// Delete a board
        /// </summary>
        [HttpDelete]
        [Route("boards/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _inMemoryBus.SendCommand<DeleteBoardRequest>(new(id));

        }



        #endregion

    }
}
