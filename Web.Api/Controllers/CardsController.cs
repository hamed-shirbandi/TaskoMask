using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Cards.Services;
using TaskoMask.Application.Core.Dtos.Cards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize]
    public class CardsController : BaseController
    {
        #region Fields

        private readonly ICardService _cardService;

        #endregion

        #region Ctors

        public CardsController(ICardService cardService, IMapper mapper) : base(mapper)
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
        public async Task<Result<CommandResult>> Create(CardInputDto input)
        {
            return await _cardService.CreateAsync(input);
        }



        /// <summary>
        /// update existing card
        /// </summary>
        [HttpPut]
        [Route("cards")]
        public async Task<Result<CommandResult>> Update(CardInputDto input)
        {
            return await _cardService.UpdateAsync(input);
        }



        #endregion

    }
}
