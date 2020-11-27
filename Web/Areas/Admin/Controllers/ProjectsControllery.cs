using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Services.Projects;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;
using TaskoMask.web.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.web.Area.Admin.Controllers
{
    [Authorize]
     [Area("admin")]
    public class ProjectsController : BaseController
    {
        #region Fields

        private readonly IProjectService _projectService;

        #endregion

        #region Ctor

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index(string organizationId)
        {
            var projects = await _projectService.GetListByOrganizationIdAsync(organizationId);
            return View(projects);
        }





        #endregion

    }
}
