using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.Owners.GetOwnerById
{

    [Authorize("user-read-access")]
    [Tags("Owners")]
    public class GetOwnerByIdEndpoint : BaseApiController
    {
        public GetOwnerByIdEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }


        /// <summary>
        /// get current owner basic information
        /// </summary>
        [HttpGet]
        [Route("owner")]
        public async Task<Result<GetOwnerDto>> Get()
        {
            return await _inMemoryBus.SendQuery(new GetOwnerByIdRequest(GetCurrentUserId()));
        }
    }

}