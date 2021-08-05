using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Cards.Services;
using TaskoMask.Application.Core.Dtos.Cards;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Application.Core.Services;
using AutoMapper;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Cards.Queries.Models;

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

        public CardsController(ICardService cardService, IBaseApplicationService baseApplicationService, IMapper mapper) : base(baseApplicationService, mapper)
        {
            _cardService = cardService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var cardDetailQueryResult = await _cardService.GetDetailAsync(id);
            return ReturnDataToViewAsync(cardDetailQueryResult);

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

            var cmd = new CreateCardCommand(boardId: input.BoardId, name: input.Name, description: input.Description, type:input.Type);
            await SendCommandAsync(cmd);

            return View(input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return await SendQueryAndReturnMappedDataToViewAsync<CardBasicInfoDto, CardInputDto>(new GetCardByIdQuery(id));
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(CardInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmd = new UpdateCardCommand(id: input.Id, name: input.Name, description: input.Description, type: input.Type);
            await SendCommandAsync(cmd);

            return View(input);
        }



        #endregion

    }
}
