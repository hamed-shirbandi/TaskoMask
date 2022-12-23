using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByOrganizationId
{

    [Authorize("user-read-access")]
    [Tags("Boards")]
    public class GetBoardsByOrganizationIdRestEndpoint : BaseApiController
    {
        public GetBoardsByOrganizationIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// get boards for an organization
        /// </summary>
        [HttpGet]
        [Route("organizations/{organizationId}/boards")]
        public async Task<Result<IEnumerable<GetBoardDto>>> Get(string organizationId)
        {
            return await _inMemoryBus.SendQuery(new GetBoardsByOrganizationIdRequest(organizationId));
        }
    }

}