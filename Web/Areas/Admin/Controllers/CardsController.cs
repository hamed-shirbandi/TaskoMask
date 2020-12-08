using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Services.Cards;
using TaskoMask.Application.Services.Cards.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;
using TaskoMask.web.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.web.Area.Admin.Controllers
{
    [Authorize]
     [Area("admin")]
    public class CardsController : BaseController
    {
        #region Fields

        private readonly ICardService _cardService;

        #endregion

        #region Ctor

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index(string boardId)
        {
            var cards = await _cardService.GetListByBoardIdAsync(boardId);
            return View(cards);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create(string boardId)
        {
            var model = new CardInput
            {
                BoardId = boardId,
            };

            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CardInput input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _cardService.CreateAsync(input);
            ValidateResult(result);

            return View(input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var card = await _cardService.GetByIdToUpdateAsync(id);
            return View(card);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(CardInput input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _cardService.UpdateAsync(input);

            ValidateResult(result);

            return View(input);
        }




        #endregion

    }
}
