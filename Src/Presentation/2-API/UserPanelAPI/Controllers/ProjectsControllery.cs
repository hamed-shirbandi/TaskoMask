using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Projects.Services;
using TaskoMask.Application.Share.Dtos.Team.Projects;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectsController : BaseApiController, IProjectClientService
    {
        #region Fields

        private readonly IProjectService _projectService;

        #endregion

        #region Ctors

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get project basic info
        /// </summary>
        [HttpGet]
        [Route("projects/{id}")]
        public async Task<Result<ProjectBasicInfoDto>> Get(string id)
        {
            return await _projectService.GetByIdAsync(id);
        }



        /// <summary>
        /// get projects list without relational data for current user
        /// </summary>
        [HttpGet]
        [Route("projects/getSelectListItems/{organizationId}")]
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string organizationId)
        {
            return await _projectService.GetSelectListAsync(GetCurrentUserId());
        }



        /// <summary>
        /// create new project
        /// </summary>
        [HttpPost]
        [Route("projects")]
        public async Task<Result<CommandResult>> Create([FromBody] ProjectUpsertDto input)
        {
            return await _projectService.CreateAsync(input);
        }



        /// <summary>
        /// update existing project
        /// </summary>
        [HttpPut]
        [Route("projects")]
        public async Task<Result<CommandResult>> Update([FromBody] ProjectUpsertDto input)
        {
            return await _projectService.UpdateAsync(input);
        }



        /// <summary>
        /// soft delete project
        /// </summary>
        [HttpDelete]
        [Route("projects")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _projectService.DeleteAsync(id);
        }



        #endregion

    }
}
