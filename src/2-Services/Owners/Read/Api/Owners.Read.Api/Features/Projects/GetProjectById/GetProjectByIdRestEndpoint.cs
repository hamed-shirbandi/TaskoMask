using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById
{

    [Authorize("user-read-access")]
    [Tags("Projects")]
    public class GetProjectByIdRestEndpoint : BaseApiController
    {
        public GetProjectByIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get project basic info
        /// </summary>
        [HttpGet]
        [Route("projects/{id}")]
        public async Task<Result<GetProjectDto>> Get(string id)
        {
            return await _inMemoryBus.SendQuery(new GetProjectByIdRequest(id));
        }
    }

}