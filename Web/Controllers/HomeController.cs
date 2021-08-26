using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using TaskoMask.Web.Models;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Projects.Services;
using TaskoMask.Application.Boards.Services;
using TaskoMask.Application.Managers.Services;
using TaskoMask.Application.Tasks.Services;

namespace TaskoMask.Web.Controllers
{
    public class HomeController : BaseMvcController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly IBoardService _boardService;
        private readonly IManagerService _managerService;

        #endregion

        #region Ctors

        public HomeController(IOrganizationService organizationService, ITaskService taskService, IBoardService boardService, IManagerService managerService)
        {
            _organizationService = organizationService;
            _taskService = taskService;
            _boardService = boardService;
            _managerService = managerService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel
            {
                //OrganizationsCount = await _organizationService.CountAsync(),
                //ProjectsCount = await _projectService.CountAsync(),
                //BoardsCount = await _boardService.CountAsync(),
                //TasksCount = await _taskService.CountAsync(),
            };

            return View(model);
        }





        #endregion

    }
}
