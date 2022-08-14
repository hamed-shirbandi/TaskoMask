using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.JwtAuthentication;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Authorization.Users.Services;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Web.Helpers;
using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Services.Monolith.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountApiController : BaseApiController, IAccountApiService
    {
        #region Fields

        private readonly IOwnerService _ownerService;
        private readonly IUserService _userService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        #endregion

        #region Ctor


        /// <summary>
        /// 
        /// </summary>
        public AccountApiController(IJwtAuthenticationService jwtAuthenticationService, IOwnerService ownerService, IMapper mapper, IUserService userService) : base(mapper)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _ownerService = ownerService;
            _userService = userService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// login owner - return jwt token if login is success
        /// </summary>
        [HttpPost]
        [Route("account/login")]
        public async Task<Result<UserJwtTokenDto>> Login([FromBody] UserLoginDto input)
        {
          
            //validate user password
            var validateQueryResult = await _userService.IsValidCredentialAsync(input.UserName, input.Password);
            if (!validateQueryResult.IsSuccess || !validateQueryResult.Value)
                return Result.Failure<UserJwtTokenDto>(validateQueryResult.Errors, validateQueryResult.Message);


            //get owner
            var ownerQueryResult = await _ownerService.GetByUserNameAsync(input.UserName);
            if (!ownerQueryResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(ownerQueryResult.Errors, ownerQueryResult.Message);


            //map to jwt claims model
            var user = _mapper.Map<AuthenticatedUser>(ownerQueryResult.Value);

            //generate jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(user);

            return Result.Success(value: new UserJwtTokenDto { JwtToken = token });
        }




        /// <summary>
        /// register new owner - return jwt token if register is success
        /// </summary>
        [HttpPost]
        [Route("account/register")]
        public async Task<Result<UserJwtTokenDto>> Register([FromBody] RegisterOwnerDto input)
        {
            //create owner with default workspace
            var createCommandResult = await _ownerService.RegisterAndSeedDefaultWorkspaceAsync(input);
            if (!createCommandResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(createCommandResult.Errors, createCommandResult.Message);

            var user = GetAuthenticatedUserModel(createCommandResult.Value.EntityId, input);

            //generate jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(user);

            return Result.Success(value: new UserJwtTokenDto { JwtToken = token });
        }






        #endregion

        #region  Private Methods


        /// <summary>
        /// 
        /// </summary>
        private AuthenticatedUser GetAuthenticatedUserModel(string entityId, RegisterOwnerDto input)
        {
            return new AuthenticatedUser
            {
                Id= entityId,
                DisplayName= input.DisplayName,
                Email= input.Email,
                UserName= input.Email,
            };
        }



        #endregion

    }


}