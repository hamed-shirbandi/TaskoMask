using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Projects.Services;
using TaskoMask.Application.Core.Dtos.Projects;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Application.Core.Services;

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

        public ProjectsController(IProjectService projectService, IBaseApplicationService baseApplicationService) : base(baseApplicationService)
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



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create(string organizationId)
        {
            var model = new ProjectInputDto
            {
                OrganizationId=organizationId,
            };

            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(ProjectInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _projectService.CreateAsync(input);
            ValidateResult(result);

            return View(input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var project = await _projectService.GetByIdToUpdateAsync(id);
            return View(project);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(ProjectInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _projectService.UpdateAsync(input);

            ValidateResult(result);

            return View(input);
        }




        #endregion

    }
}
