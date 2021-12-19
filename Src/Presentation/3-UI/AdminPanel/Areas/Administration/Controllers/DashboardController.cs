using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Domain.Share.Services;
using TaskoMask.Presentation.UI.AdminPanle.Area.Admin.Models;
using TaskoMask.Application.Team.Members.Services;
using TaskoMask.Application.Team.Projects.Services;
using TaskoMask.Application.Workspace.Tasks.Services;
using TaskoMask.Application.Workspace.Boards.Services;

namespace TaskoMask.Presentation.UI.AdminPanle.Areas.Administration.Controllers
{
    [Authorize]
    [Area("administration")]
    public class DashboardController : BaseMvcController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly IBoardService _boardService;
        private readonly IMemberService _memberService;

        #endregion

        #region Ctors

        public DashboardController(IOrganizationService organizationService, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IProjectService projectService, ITaskService taskService, IBoardService boardService, IMemberService memberService) : base(mapper, authenticatedUserService)
        {
            _organizationService = organizationService;
            _projectService = projectService;
            _taskService = taskService;
            _boardService = boardService;
            _memberService = memberService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var model = new DashboardIndexViewModel
            {
                OrganizationsCount = (await _organizationService.CountAsync()).Value,
                ProjectsCount = (await _projectService.CountAsync()).Value,
                BoardsCount = (await _boardService.CountAsync()).Value,
                TasksCount = (await _taskService.CountAsync()).Value,
                MembersCount = (await _memberService.CountAsync()).Value,
            };
            return View(model);
        }





        #endregion

    }
}
