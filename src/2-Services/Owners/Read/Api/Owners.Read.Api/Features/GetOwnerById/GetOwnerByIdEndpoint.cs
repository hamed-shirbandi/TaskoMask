using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Read.Api.Features.GetOwnerById
{

    [Authorize("user-read-access")]
    public class GetOwnerByIdEndpoint : BaseApiController
    {
        public GetOwnerByIdEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus, INotificationHandler notifications) : base(authenticatedUserService, inMemoryBus, notifications)
        {
        }


        /// <summary>
        /// get current owner basic information
        /// </summary>
        [HttpGet]
        [Route("owner")]
        public async Task<Result<OwnerBasicInfoDto>> Get()
        {
            return await SendQueryAsync(new GetOwnerByIdRequest(GetCurrentUserId()));
        }
    }

}