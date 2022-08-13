﻿using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BoardsApiController : BaseApiController, IBoardApiService
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
        public async Task<Result<BoardOutputDto>> Get(string id)
        {
            if (!await _userAccessManagementService.CanAccessToBoardAsync(id))
                return Result.Failure<BoardOutputDto>(message: DomainMessages.Access_Denied);

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
                return Result.Failure<BoardDetailsViewModel>(message: DomainMessages.Access_Denied);

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
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

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
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

            return await _boardService.DeleteAsync(id);
        }




        #endregion

    }
}
