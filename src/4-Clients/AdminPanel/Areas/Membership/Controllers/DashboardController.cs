using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Clients.AdminPanle.Area.Admin.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Services;

namespace TaskoMask.Clients.AdminPanle.Areas.Membership.Controllers
{
    [Authorize]
    [Area("membership")]
    public class DashboardController : BaseMvcController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly IBoardService _boardService;
        private readonly IOwnerService _ownerService;

        #endregion

        #region Ctors

        public DashboardController(IOrganizationService organizationService, IMapper mapper, IAuthenticatedUserService authenticatedUserService, IProjectService projectService, ITaskService taskService, IBoardService boardService, IOwnerService ownerService) : base(mapper, authenticatedUserService)
        {
            _organizationService = organizationService;
            _projectService = projectService;
            _taskService = taskService;
            _boardService = boardService;
            _ownerService = ownerService;
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
                OwnersCount = (await _ownerService.CountAsync()).Value,
            };
            return View(model);
        }





        #endregion

    }
}
