using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId
{

    [Authorize("user-read-access")]
    [Tags("Projects")]
    public class GetProjectsByOrganizationIdRestEndpoint : BaseApiController
    {
        public GetProjectsByOrganizationIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get projects for an organization
        /// </summary>
        [HttpGet]
        [Route("organizations/{organizationId}/projects")]
        public async Task<Result<IEnumerable<GetProjectDto>>> Get(string organizationId)
        {
            return await _inMemoryBus.SendQuery(new GetProjectsByOrganizationIdRequest(organizationId));
        }
    }

}