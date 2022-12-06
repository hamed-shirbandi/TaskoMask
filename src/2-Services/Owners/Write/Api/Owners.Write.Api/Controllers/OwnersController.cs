using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.UpdateOwnerProfile;

namespace TaskoMask.Services.Owners.Write.Api.Controllers
{
    [Authorize("user-write-access")]
    public class OwnersController : BaseApiController
    {
        #region Fields


        #endregion

        #region Ctors

        public OwnersController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
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
            return await _inMemoryBus.SendCommand<RegiserOwnerRequest>(new(displayName: input.DisplayName, email: input.Email, password: input.Password));
        }




        /// <summary>
        /// Update current owner
        /// </summary>
        [HttpPut]
        [Route("owner")]
        public async Task<Result<CommandResult>> UpdateProfile([FromBody] UpdateOwnerProfileDto input)
        {
            return await _inMemoryBus.SendCommand<UpdateOwnerProfileRequest>(new(id: input.Id, displayName: input.DisplayName, email: input.Email));
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
