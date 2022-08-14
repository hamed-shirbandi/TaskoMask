using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Services;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Cards;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CardsApiController : BaseApiController, ICardApiService
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
        public async Task<Result<CardBasicInfoDto>> Get(string id)
        {
            if (!await _userAccessManagementService.CanAccessToCardAsync(id))
                return Result.Failure<CardBasicInfoDto>(message: DomainMessages.Access_Denied);

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
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

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
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

            return await _cardService.DeleteAsync(id);
        }




        #endregion

    }
}
