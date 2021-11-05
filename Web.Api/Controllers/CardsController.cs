using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.TaskManagement.Cards.Services;
using TaskoMask.Application.Core.Dtos.TaskManagement.Cards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CardsController : BaseApiController
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
