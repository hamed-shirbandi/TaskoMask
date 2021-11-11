using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Team.Projects.Services;
using System.Threading.Tasks;
using TaskoMask.Web.Common.Filters;

namespace Aghoosh.Web.Admin.Areas.Accounting.Controllers
{
    [Authorize]
    [Area("Team")]
    public class ProjectsController : BaseMvcController
    {
        #region Fields

        private readonly IProjectService _projectService;


        #endregion

        #region Ctor

        public ProjectsController(IProjectService projectService, IMapper mapper) : base(mapper)
        {
            _projectService = projectService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projectQueryResult = await _projectService.SearchAsync(page: 1, recordsPerPage: recordsPerPage, term: "");

            #region ViewBags

            ViewBag.PageSize = projectQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = 1;
            ViewBag.TotalItemCount = projectQueryResult.Value.TotalCount;

            #endregion

            return View(projectQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> Search(int page = 1, string term = "")
        {
            var projectQueryResult = await _projectService.SearchAsync(page: page, recordsPerPage: recordsPerPage, term: term);

            if (!projectQueryResult.IsSuccess)
                return RedirectToErrorPage(projectQueryResult);

            #region ViewBags

            ViewBag.PageSize = projectQueryResult.Value.PageNumber;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = projectQueryResult.Value.TotalCount;

            #endregion

            return PartialView("_ItemList", projectQueryResult.Value.Items);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var projectQueryResult = await _projectService.GetDetailsAsync(id);

            return View(projectQueryResult);

        }





        #endregion

        #region Private Methods



        #endregion

    }
}
