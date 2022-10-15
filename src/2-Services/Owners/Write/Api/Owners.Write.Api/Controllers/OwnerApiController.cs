using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Contracts.ApiContracts.Owners;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;

namespace TaskoMask.Services.Owners.Write.Api.Controllers
{
    public class OwnerApiController : BaseApiController, IOwnerWriteApiService
    {
        #region Fields


        #endregion

        #region Ctors

        public OwnerApiController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus, INotificationHandler notifications) : base(authenticatedUserService, inMemoryBus, notifications)
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
            return await SendCommandAsync<RegiserOwnerRequest>(new(displayName: input.DisplayName, email: input.Email, password: input.Password));
        }




        /// <summary>
        /// Update current owner
        /// </summary>
        [HttpPut]
        [Route("owner")]
        public async Task<Result<CommandResult>> UpdateProfile([FromBody] UpdateOwnerProfileDto input)
        {
            //input.Id = GetCurrentUserId();
            // return await _ownerService.UpdateProfileAsync(input);
            //TODO 
            return Result.Failure<CommandResult>();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
