using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Domain.Core.Services;

namespace TaskoMask.Services.Monolith.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OwnerApiController : BaseApiController, IOwnerApiService
    {
        #region Fields

        private readonly IOwnerService _ownerService;

        #endregion

        #region Ctors

        public OwnerApiController(IOwnerService ownerService, IAuthenticatedUserService authenticatedUserService) : base(authenticatedUserService)
        {
            _ownerService = ownerService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get current owner basic information
        /// </summary>
        [HttpGet]
        [Route("owner")]
        public async Task<Result<OwnerBasicInfoDto>> Get()
        {
            return await _ownerService.GetByIdAsync(GetCurrentUserId());
        }




        /// <summary>
        /// Update current owner
        /// </summary>
        [HttpPut]
        [Route("owner")]
        public async Task<Result<CommandResult>> UpdateProfile([FromBody] UpdateOwnerProfileDto input)
        {
            input.Id = GetCurrentUserId();
            return await _ownerService.UpdateProfileAsync(input);
        }



        #endregion

    }
}
