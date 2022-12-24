using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId
{

    [Authorize("user-read-access")]
    [Tags("Organizations")]
    public class GetOrganizationsByOwnerIdRestEndpoint : BaseApiController
    {
        public GetOrganizationsByOwnerIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get organizations for current owner
        /// </summary>
        [HttpGet]
        [Route("organizations")]
        public async Task<Result<IEnumerable<GetOrganizationDto>>> Get()
        {
            return await _inMemoryBus.SendQuery(new GetOrganizationsByOwnerIdRequest(GetCurrentUserId()));
        }
    }

}