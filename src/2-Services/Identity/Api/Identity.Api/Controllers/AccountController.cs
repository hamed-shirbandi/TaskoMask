using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.JwtAuthentication;
using TaskoMask.Services.Identity.Application.Users.Services;
using TaskoMask.BuildingBlocks.Contracts.Enums;

namespace TaskoMask.Services.Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : BaseApiController, IAccountApiService
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        #endregion

        #region Ctor


        /// <summary>
        /// 
        /// </summary>
        public AccountController(IJwtAuthenticationService jwtAuthenticationService, IUserService userService) : base()
        {
            _jwtAuthenticationService = jwtAuthenticationService;
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
            //TODO refactor with Identity Server

            //validate user password
            var validateQueryResult = await _userService.IsValidCredentialAsync(input.UserName, input.Password);
            if (!validateQueryResult.IsSuccess || !validateQueryResult.Value)
                return Result.Failure<UserJwtTokenDto>(validateQueryResult.Errors, validateQueryResult.Message);


            //get owner
            var userQueryResult = await _userService.GetByUserNameAsync(input.UserName);
            if (!userQueryResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(userQueryResult.Errors, userQueryResult.Message);


            //map to jwt claims model
            var user = GetAuthenticatedUserModel(userQueryResult.Value);

            //generate jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(user);

            return Result.Success(value: new UserJwtTokenDto { JwtToken = token });
        }





        #endregion

        #region  Private Methods


        /// <summary>
        /// 
        /// </summary>
        private AuthenticatedUserModel GetAuthenticatedUserModel( UserBasicInfoDto user)
        {
            return new AuthenticatedUserModel
            {
                Id = user.Id,
                Email = user.UserName,
                UserName = user.UserName,
            };
        }



        #endregion

    }


}