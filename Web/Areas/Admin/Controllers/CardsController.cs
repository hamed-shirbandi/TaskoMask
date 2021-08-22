using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Cards.Services;
using TaskoMask.Application.Core.Dtos.Cards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
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
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var cardDetailQueryResult = await _cardService.GetDetailsAsync(id);
            return View(cardDetailQueryResult);

        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create(string boardId)
        {
            var model = new CardInputDto
            {
                BoardId = boardId,
            };
            return View(model);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CardInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmdResult = await _cardService.CreateAsync(input);
            return View(cmdResult, input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var cardQueryResult = await _cardService.GetByIdAsync(id);
            return View<CardBasicInfoDto, CardInputDto>(cardQueryResult);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(CardInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmdResult = await _cardService.UpdateAsync(input);
            return View(cmdResult, input);
        }



        #endregion

    }
}
