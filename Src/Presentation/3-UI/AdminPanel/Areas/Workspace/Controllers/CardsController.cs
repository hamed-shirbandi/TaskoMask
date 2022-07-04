using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.Presentation.Framework.Web.Controllers;
using System.Threading.Tasks;
using TaskoMask.Presentation.Framework.Web.Filters;
using TaskoMask.Application.Workspace.Cards.Services;

namespace TaskoMask.Presentation.UI.AdminPanle.Areas.Workspace.Controllers
{
    [Authorize]
    [Area("Workspace")]
    public class CardsController : BaseMvcController
    {
        #region Fields

        private readonly ICardService _cardService;


        #endregion

        #region Ctor

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
        public async Task<IActionResult> Index()
        {
            var cardQueryResult = await _cardService.SearchAsync(page: 1, recordsPerPage: recordsPerPage, term: "");

            #region ViewBags

            ViewBag.PageSize = cardQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = 1;
            ViewBag.TotalItemCount = cardQueryResult.Value.TotalCount;

            #endregion

            return View(cardQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> Search(int page = 1, string term = "")
        {
            var cardQueryResult = await _cardService.SearchAsync(page: page, recordsPerPage: recordsPerPage, term: term);

            if (!cardQueryResult.IsSuccess)
                return RedirectToErrorPage(cardQueryResult);

            #region ViewBags

            ViewBag.PageSize = cardQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = cardQueryResult.Value.TotalCount;

            #endregion

            return PartialView("_ItemList", cardQueryResult.Value.Items);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var cardQueryResult = await _cardService.GetCardDetailsListByBoardIdAsync(id);

            return View(cardQueryResult);

        }





        #endregion

        #region Private Methods



        #endregion

    }
}
