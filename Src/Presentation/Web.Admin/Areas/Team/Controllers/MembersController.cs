using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Team.Members.Services;
using System.Threading.Tasks;
using TaskoMask.Web.Common.Filters;
using TaskoMask.Web.Common.Helpers;

namespace Aghoosh.Web.Admin.Areas.Accounting.Controllers
{
    [Authorize]
    [Area("Accounting")]
    public class MembersController : BaseMvcController
    {
        #region Fields

        private readonly IMemberService _memberService;


        #endregion

        #region Ctor

        public MembersController(IMemberService memberService, IMapper mapper) : base(mapper)
        {
            _memberService = memberService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var memberQueryResult = await _memberService.SearchAsync(page: 1, recordsPerPage: recordsPerPage, term: "");

            #region ViewBags

            ViewBag.PageSize = memberQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = 1;
            ViewBag.TotalItemCount = memberQueryResult.Value.TotalCount;

            #endregion

            return View(memberQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> Search(int page = 1, string term = "")
        {
            var memberQueryResult = await _memberService.SearchAsync(page: page, recordsPerPage: recordsPerPage, term: term);

            if (!memberQueryResult.IsSuccess)
                return RedirectToErrorPage(memberQueryResult);

            #region ViewBags

            ViewBag.PageSize = memberQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = memberQueryResult.Value.TotalCount;

            #endregion

            return PartialView("_ItemList", memberQueryResult.Value.Items);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var memberQueryResult = await _memberService.GetDetailsAsync(id);

            return View(memberQueryResult);

        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [IgnoreAntiforgeryToken]
        public async Task<JavaScriptResult> SetIsActive(string id, bool isActive)
        {
            var cmdResult = await _memberService.SetIsActiveAsync(id, isActive);
            return AjaxResult(cmdResult, reloadPage: true);

        }




        #endregion

        #region Private Methods



        #endregion

    }
}
