using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.Services.Monolith.Api.Controllers
{
    [Authorize("full-access")]
    public class CardsApiController : BaseApiController
    {
        #region Fields

        private readonly ICardService _cardService;
        private readonly IUserAccessManagementService _userAccessManagementService;

        #endregion

        #region Ctors

        public CardsApiController(ICardService cardService, IUserAccessManagementService userAccessManagementService)
        {
            _cardService = cardService;
            _userAccessManagementService = userAccessManagementService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get card detail
        /// </summary>
        [HttpGet]
        [Route("cards/{id}")]
        public async Task<Result<GetCardDto>> Get(string id)
        {
            if (!await _userAccessManagementService.CanAccessToCardAsync(id))
                return Result.Failure<GetCardDto>(message: ContractsMessages.Access_Denied);

            return await _cardService.GetByIdAsync(id);
        }



        /// <summary>
        /// get cards select list for a board
        /// </summary>
        [HttpGet]
        [Route("boards/{boardId}/cards")]
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string boardId)
        {
            return await _cardService.GetSelectListAsync(boardId);
        }



        /// <summary>
        /// create new card
        /// </summary>
        [HttpPost]
        [Route("cards")]
        public async Task<Result<CommandResult>> Add([FromBody] AddCardDto input)
        {
            return await _cardService.AddAsync(input);
        }



        /// <summary>
        /// update existing card
        /// </summary>
        [HttpPut]
        [Route("cards/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] UpdateCardDto input)
        {
            if (!await _userAccessManagementService.CanAccessToCardAsync(id))
                return Result.Failure<CommandResult>(message: ContractsMessages.Access_Denied);

            input.Id = id;
            return await _cardService.UpdateAsync(input);
        }



        /// <summary>
        /// soft delete card
        /// </summary>
        [HttpDelete]
        [Route("cards/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            if (!await _userAccessManagementService.CanAccessToCardAsync(id))
                return Result.Failure<CommandResult>(message: ContractsMessages.Access_Denied);

            return await _cardService.DeleteAsync(id);
        }




        #endregion

    }
}
