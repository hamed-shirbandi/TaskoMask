using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Contracts.ApiContracts.Owners;

namespace TaskoMask.Services.Owners.Write.Api.Controllers
{
    public class OwnerApiController : BaseApiController, IOwnerApiService
    {
        #region Fields


        #endregion

        #region Ctors

        public OwnerApiController( IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus, INotificationHandler notifications) : base(authenticatedUserService, inMemoryBus, notifications)
        {
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// register new owner
        /// </summary>
        [HttpPost]
        [Route("owner")]
        [AllowAnonymous]

        public async Task<Result<CommandResult>> Register([FromBody] RegisterOwnerDto input)
        {
            // return await _ownerService.RegisterAsync(input);
            return Result.Failure<CommandResult>();
        }






        /// <summary>
        /// get current owner basic information
        /// </summary>
        [HttpGet]
        [Route("owner")]
        public async Task<Result<OwnerBasicInfoDto>> Get()
        {
           // return await _ownerService.GetByIdAsync(GetCurrentUserId());
            return Result.Failure<OwnerBasicInfoDto>();
        }




        /// <summary>
        /// Update current owner
        /// </summary>
        [HttpPut]
        [Route("owner")]
        public async Task<Result<CommandResult>> UpdateProfile([FromBody] UpdateOwnerProfileDto input)
        {
            input.Id = GetCurrentUserId();
           // return await _ownerService.UpdateProfileAsync(input);
            return Result.Failure<CommandResult>();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
