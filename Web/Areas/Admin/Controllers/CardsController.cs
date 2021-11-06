using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Cards.Services;
using TaskoMask.Application.Core.Dtos.Workspace.Cards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class CardsController : BaseMvcController
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
            var model = new CardUpsertDto
            {
                BoardId = boardId,
            };
            return View(model);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CardUpsertDto input)
        {
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
            return View<CardBasicInfoDto, CardUpsertDto>(cardQueryResult);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(CardUpsertDto input)
        {
            var cmdResult = await _cardService.UpdateAsync(input);
            return View(cmdResult, input);
        }



        #endregion

    }
}
