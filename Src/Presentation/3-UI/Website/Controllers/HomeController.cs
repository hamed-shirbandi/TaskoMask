using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Presentation.UI.Website.Models;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Workspace.Projects.Services;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Workspace.Members.Services;
using TaskoMask.Application.Workspace.Tasks.Services;

namespace TaskoMask.Presentation.UI.Website.Controllers
{
    public class HomeController : BaseMvcController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly IBoardService _boardService;
        private readonly IMemberService _memberService;

        #endregion

        #region Ctors

        public HomeController(IOrganizationService organizationService, ITaskService taskService, IBoardService boardService, IMemberService memberService, IProjectService projectService)
        {
            _organizationService = organizationService;
            _taskService = taskService;
            _boardService = boardService;
            _memberService = memberService;
            _projectService = projectService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            //TODO cache this queries
            var model = new HomeIndexViewModel
            {
                OrganizationsCount = (await _organizationService.CountAsync()).Value,
                ProjectsCount = (await _projectService.CountAsync()).Value,
                BoardsCount = (await _boardService.CountAsync()).Value,
                TasksCount = (await _taskService.CountAsync()).Value,
                MembersCount= (await _memberService.CountAsync()).Value,
            };

            return View(model);
        }





        #endregion

    }
}
