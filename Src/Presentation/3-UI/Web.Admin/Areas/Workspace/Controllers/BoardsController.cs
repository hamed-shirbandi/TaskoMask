using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.Presentation.Framework.Web.Controllers;
using System.Threading.Tasks;
using TaskoMask.Presentation.Framework.Web.Filters;
using TaskoMask.Presentation.Framework.Web.Helpers;
using TaskoMask.Application.Workspace.Boards.Services;

namespace TaskoMask.Presentation.UI.AdminPanle.Areas.Workspace.Controllers
{
    [Authorize]
    [Area("Workspace")]
    public class BoardsController : BaseMvcController
    {
        #region Fields

        private readonly IBoardService _boardService;


        #endregion

        #region Ctor

        public BoardsController(IBoardService boardService, IMapper mapper) : base(mapper)
        {
            _boardService = boardService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var boardQueryResult = await _boardService.SearchAsync(page: 1, recordsPerPage: recordsPerPage, term: "");

            #region ViewBags

            ViewBag.PageSize = boardQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = 1;
            ViewBag.TotalItemCount = boardQueryResult.Value.TotalCount;

            #endregion

            return View(boardQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> Search(int page = 1, string term = "")
        {
            var boardQueryResult = await _boardService.SearchAsync(page: page, recordsPerPage: recordsPerPage, term: term);

            if (!boardQueryResult.IsSuccess)
                return RedirectToErrorPage(boardQueryResult);

            #region ViewBags

            ViewBag.PageSize = boardQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = boardQueryResult.Value.TotalCount;

            #endregion

            return PartialView("_ItemList", boardQueryResult.Value.Items);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var boardQueryResult = await _boardService.GetDetailsAsync(id);

            return View(boardQueryResult);

        }




        #endregion

        #region Private Methods



        #endregion

    }
}
