using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Cards.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CardsController : BaseApiController, ICardClientService
    {
        #region Fields

        private readonly ICardService _cardService;

        #endregion

        #region Ctors

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get card detail
        /// </summary>
        [HttpGet]
        [Route("cards/{id}")]
        public async Task<Result<CardDetailsViewModel>> Get(string id)
        {
            return await _cardService.GetDetailsAsync(id);
        }



        /// <summary>
        /// create new card
        /// </summary>
        [HttpPost]
        [Route("cards")]
        public async Task<Result<CommandResult>> Create(CardUpsertDto input)
        {
            return await _cardService.CreateAsync(input);
        }



        /// <summary>
        /// update existing card
        /// </summary>
        [HttpPut]
        [Route("cards")]
        public async Task<Result<CommandResult>> Update(CardUpsertDto input)
        {
            return await _cardService.UpdateAsync(input);
        }



        #endregion

    }
}
