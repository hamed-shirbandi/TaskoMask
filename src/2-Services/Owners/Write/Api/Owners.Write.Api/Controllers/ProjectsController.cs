using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.UpdateProject;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.DeleteProject;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.Services.Owners.Write.Api.Controllers
{
    [Authorize("user-write-access")]
    public class ProjectsController : BaseApiController
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
            return await _inMemoryBus.SendCommand<UpdateProjectRequest>(new(id: input.Id, name: input.Name, description: input.Description));
        }



        /// <summary>
        /// Delete a project
        /// </summary>
        [HttpDelete]
        [Route("projects/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _inMemoryBus.SendCommand<DeleteProjectRequest>(new(id));

        }



        #endregion

    }
}
