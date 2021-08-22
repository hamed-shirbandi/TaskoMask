using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Projects.Services;
using TaskoMask.Application.Core.Dtos.Projects;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectsController : BaseController
    {
        #region Fields

        private readonly IProjectService _projectService;

        #endregion

        #region Ctors

        public ProjectsController(IProjectService projectService, IMapper mapper) : base(mapper)
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
        public async Task<Result<CommandResult>> Create(ProjectInputDto input)
        {
            return await _projectService.CreateAsync(input);
        }



        /// <summary>
        /// update existing project
        /// </summary>
        [HttpPut]
        [Route("projects")]
        public async Task<Result<CommandResult>> Update(ProjectInputDto input)
        {
            return await _projectService.UpdateAsync(input);
        }



        #endregion

    }
}
