using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Projects.Services;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectsController : BaseApiController, IProjectWebService
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
        /// get project detail
        /// </summary>
        [HttpGet]
        [Route("projects/{id}")]
        public async Task<Result<ProjectDetailsViewModel>> Get(string id)
        {
            return await _projectService.GetDetailsAsync(id);
        }



        /// <summary>
        /// create new project
        /// </summary>
        [HttpPost]
        [Route("projects")]
        public async Task<Result<CommandResult>> Create(ProjectUpsertDto input)
        {
            return await _projectService.CreateAsync(input);
        }



        /// <summary>
        /// update existing project
        /// </summary>
        [HttpPut]
        [Route("projects")]
        public async Task<Result<CommandResult>> Update(ProjectUpsertDto input)
        {
            return await _projectService.UpdateAsync(input);
        }



        #endregion

    }
}
