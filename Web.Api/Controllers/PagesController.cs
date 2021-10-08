using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.TaskManagement.Boards.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Application.Team.Organizations.Services;
using TaskoMask.Web.Api.Models;
using TaskoMask.Application.Team.Members.Services;
using TaskoMask.Application.TaskManagement.Tasks.Services;
using TaskoMask.Application.Team.Projects.Services;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PagesController : BaseApiController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly IBoardService _boardService;
        private readonly IMemberService _memberService;

        #endregion

        #region Ctors

        public PagesController(IOrganizationService organizationService, ITaskService taskService, IBoardService boardService, IMemberService memberService, IProjectService projectService)
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
        /// Get site's home page data 
        /// </summary>
        [HttpPost]
        [Route("boards")]
        public async Task<Result<HomeIndexViewModel>> Home()
        {
            //TODO cache this queries (also can cache the action)
            var model= new HomeIndexViewModel
            {
                OrganizationsCount = (await _organizationService.CountAsync()).Value,
                ProjectsCount = (await _projectService.CountAsync()).Value,
                BoardsCount = (await _boardService.CountAsync()).Value,
                TasksCount = (await _taskService.CountAsync()).Value,
                MembersCount = (await _memberService.CountAsync()).Value,
            };

            return Result.Success(model);

        }






        #endregion

    }
}
