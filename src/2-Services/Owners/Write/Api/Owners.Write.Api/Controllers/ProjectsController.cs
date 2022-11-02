using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Api.OwProjectsners;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject;

namespace TaskoMask.Services.Owners.Write.Api.Controllers
{
    public class ProjectsController : BaseApiController, IProjectWriteApiService
    {
        #region Fields


        #endregion

        #region Ctors

        public ProjectsController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// Add new project
        /// </summary>
        [HttpPost]
        [Route("projects")]
        public async Task<Result<CommandResult>> Add([FromBody] AddProjectDto input)
        {
            return await _inMemoryBus.SendCommand<AddProjectRequest>(new(organizationId: input.OrganizationId, name: input.Name, description: input.Description));
        }



        /// <summary>
        /// Update an existing project
        /// </summary>
        [HttpPut]
        [Route("projects/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] UpdateProjectDto input)
        {
            return Result.Failure<CommandResult>();
        }



        /// <summary>
        /// Delete a project
        /// </summary>
        [HttpDelete]
        [Route("projects/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return Result.Failure<CommandResult>();
        }



        #endregion

    }
}
