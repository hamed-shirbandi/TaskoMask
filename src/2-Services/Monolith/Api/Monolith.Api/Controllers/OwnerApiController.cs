using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.JwtAuthentication;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OwnerApiController : BaseApiController, IOwnerApiService
    {
        #region Fields

        private readonly IOwnerService _ownerService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        #endregion

        #region Ctors

        public OwnerApiController(IOwnerService ownerService, IAuthenticatedUserService authenticatedUserService, IJwtAuthenticationService jwtAuthenticationService) : base(authenticatedUserService)
        {
            _ownerService = ownerService;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// register new owner - return jwt token if register is success
        /// </summary>
        [HttpPost]
        [Route("owner")]
        [AllowAnonymous]
        public async Task<Result<UserJwtTokenDto>> Register([FromBody] RegisterOwnerDto input)
        {
            //TODO refactor with Identity Server


            //create owner with default workspace
            var createCommandResult = await _ownerService.RegisterAndSeedDefaultWorkspaceAsync(input);
            if (!createCommandResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(createCommandResult.Errors, createCommandResult.Message);

            var user = GetAuthenticatedUserModel(createCommandResult.Value.EntityId, input);

            //generate jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(user);

            return Result.Success(value: new UserJwtTokenDto { JwtToken = token });
        }






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


        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private AuthenticatedUserModel GetAuthenticatedUserModel(string id, RegisterOwnerDto owner)
        {
            return new AuthenticatedUserModel
            {
                Id = id,
                DisplayName = owner.DisplayName,
                Email = owner.Email,
                UserName = owner.Email,
            };
        }


        #endregion

    }
}
