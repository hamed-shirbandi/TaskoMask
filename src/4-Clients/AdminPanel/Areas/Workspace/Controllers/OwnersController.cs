using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Web.MVC.Filters;
using TaskoMask.BuildingBlocks.Web.MVC.Helpers;
using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Clients.AdminPanle.Areas.Workspace.Controllers
{
    [Authorize]
    [Area("Workspace")]
    public class OwnersController : BaseMvcController
    {
        #region Fields

        private readonly IOwnerService _ownerService;
        private readonly IUserApiService _userApiService;


        #endregion

        #region Ctor

        public OwnersController(IOwnerService ownerService, IMapper mapper, IUserApiService userApiService) : base()
        {
            _ownerService = ownerService;
            _userApiService = userApiService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ownerQueryResult = await _ownerService.SearchAsync(page: 1, recordsPerPage: recordsPerPage, term: "");

            #region ViewBags

            ViewBag.PageSize = ownerQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = 1;
            ViewBag.TotalItemCount = ownerQueryResult.Value.TotalCount;

            #endregion

            return View(ownerQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> Search(int page = 1, string term = "")
        {
            var ownerQueryResult = await _ownerService.SearchAsync(page: page, recordsPerPage: recordsPerPage, term: term);

            if (!ownerQueryResult.IsSuccess)
                return RedirectToErrorPage(ownerQueryResult);

            #region ViewBags

            ViewBag.PageSize = ownerQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = ownerQueryResult.Value.TotalCount;

            #endregion

            return PartialView("_ItemList", ownerQueryResult.Value.Items);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var ownerQueryResult = await _ownerService.GetDetailsAsync(id);

            return View(ownerQueryResult);

        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [IgnoreAntiforgeryToken]
        public async Task<JavaScriptResult> SetIsActive(string id, bool isActive)
        {
            var cmdResult = await _userApiService.SetIsActive(id, isActive);
            return AjaxResult(cmdResult);
        }




        #endregion

        #region Private Methods



        #endregion

    }
}
