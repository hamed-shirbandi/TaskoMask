using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Cards.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CardsController : BaseApiController, ICardApiService
    {
        #region Fields

        private readonly ICardService _cardService;
        private readonly IUserAccessManagementService _userAccessManagementService;

        #endregion

        #region Ctors

        public CardsController(ICardService cardService, IUserAccessManagementService userAccessManagementService)
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
        public async Task<Result<CommandResult>> Create([FromBody] CardUpsertDto input)
        {
            return await _cardService.CreateAsync(input);
        }



        /// <summary>
        /// update existing card
        /// </summary>
        [HttpPut]
        [Route("cards/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] CardUpsertDto input)
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
