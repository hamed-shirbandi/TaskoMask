using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Workspace.Owners.Services;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.JwtAuthentication;
using TaskoMask.Domain.Share.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Application.Authorization.Users.Services;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    public class AccountController : BaseApiController, IAccountClientService
    {
        #region Fields

        private readonly IOwnerService _ownerService;
        private readonly IUserService _userService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        #endregion

        #region Ctor

        public AccountController(IJwtAuthenticationService jwtAuthenticationService, IOwnerService ownerService, IMapper mapper, IUserService userService) : base(mapper)
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
            //get user
            var userQueryResult = await _userService.GetByUserNameAsync(input.UserName);
            if (!userQueryResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(userQueryResult.Errors, userQueryResult.Message);

            //validate user password
            var validateQueryResult = await _userService.IsValidCredentialAsync(input.UserName, input.Password);
            if (!validateQueryResult.IsSuccess || !validateQueryResult.Value)
                return Result.Failure<UserJwtTokenDto>(userQueryResult.Errors, validateQueryResult.Message);


            //get owner
            var ownerQueryResult = await _ownerService.GetByIdAsync(userQueryResult.Value.Id);
            if (!ownerQueryResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(ownerQueryResult.Errors, ownerQueryResult.Message);


            //map to jwt claims model
            var user = _mapper.Map<AuthenticatedUser>(ownerQueryResult.Value);

            //generate jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(user);

            return Result.Success(value: new UserJwtTokenDto { JwtToken=token});
        }




        /// <summary>
        /// register new owner - return jwt token if register is success
        /// </summary>
        [HttpPost]
        [Route("account/register")]
        public async Task<Result<UserJwtTokenDto>> Register([FromBody] OwnerRegisterDto input)
        {
            //create owner
            var createCommandResult = await _ownerService.CreateAsync(input);
            if (!createCommandResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(createCommandResult.Errors, createCommandResult.Message);

            //get owner
            var ownerQueryResult = await _ownerService.GetByIdAsync(createCommandResult.Value.EntityId);
            if (!ownerQueryResult.IsSuccess)
                return Result.Failure<UserJwtTokenDto>(ownerQueryResult.Errors, ownerQueryResult.Message);

            //map to jwt claims model
            var user = _mapper.Map<AuthenticatedUser>(ownerQueryResult.Value);

            //generate jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(user);

            return Result.Success(value: new UserJwtTokenDto { JwtToken = token });
        }




        #endregion

        #region  Private Methods






        #endregion

    }


}