using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetProjectById
{

    [Authorize("user-read-access")]
    public partial class ProjectsController : BaseApiController
    {
        public ProjectsController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get project detail information
        /// </summary>
        [HttpGet]
        [Route("projects/{id}")]
        public async Task<Result<ProjectDetailsViewModel>> GetProjectById(string id)
        {
            return await _inMemoryBus.SendQuery(new GetProjectByIdRequest(id));
        }
    }

}