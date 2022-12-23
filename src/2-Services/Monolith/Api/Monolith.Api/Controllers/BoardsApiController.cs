using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.Services.Monolith.Api.Controllers
{
    [Authorize("full-access")]
    public class BoardsApiController : BaseApiController
    {
        #region Fields

        private readonly IBoardService _boardService;
        private readonly IUserAccessManagementService _userAccessManagementService;

        #endregion

        #region Ctors

        public BoardsApiController(IBoardService boardService, IUserAccessManagementService userAccessManagementService)
        {
            _boardService = boardService;
            _userAccessManagementService = userAccessManagementService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// get board basic info
        /// </summary>
        [HttpGet]
        [Route("boards/{id}")]
        public async Task<Result<GetBoardDto>> Get(string id)
        {
            if (!await _userAccessManagementService.CanAccessToBoardAsync(id))
                return Result.Failure<GetBoardDto>(message: ContractsMessages.Access_Denied);

            return await _boardService.GetByIdAsync(id);
        }




        /// <summary>
        /// get board detail
        /// </summary>
        [HttpGet]
        [Route("boards/{id}/details")]
        public async Task<Result<BoardDetailsViewModel>> GetDetails(string id)
        {
            if (!await _userAccessManagementService.CanAccessToBoardAsync(id))
                return Result.Failure<BoardDetailsViewModel>(message: ContractsMessages.Access_Denied);

            return await _boardService.GetDetailsAsync(id);
        }



        /// <summary>
        /// create new board
        /// </summary>
        [HttpPost]
        [Route("boards")]
        public async Task<Result<CommandResult>> Add([FromBody] AddBoardDto input)
        {
            return await _boardService.AddAsync(input);
        }



        /// <summary>
        /// update existing board
        /// </summary>
        [HttpPut]
        [Route("boards/{id}")]
        public async Task<Result<CommandResult>> Update(string id, [FromBody] UpdateBoardDto input)
        {
            if (!await _userAccessManagementService.CanAccessToBoardAsync(id))
                return Result.Failure<CommandResult>(message: ContractsMessages.Access_Denied);

            input.Id = id;
            return await _boardService.UpdateAsync(input);
        }




        /// <summary>
        /// soft delete board
        /// </summary>
        [HttpDelete]
        [Route("boards/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            if (!await _userAccessManagementService.CanAccessToBoardAsync(id))
                return Result.Failure<CommandResult>(message: ContractsMessages.Access_Denied);

            return await _boardService.DeleteAsync(id);
        }




        #endregion

    }
}
