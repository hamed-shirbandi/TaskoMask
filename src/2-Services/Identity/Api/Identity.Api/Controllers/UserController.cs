using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.Services.Identity.Application.Users.Services;

namespace TaskoMask.Services.Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserController : BaseApiController, IUserApiService
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctor


        /// <summary>
        /// 
        /// </summary>
        public UserController(IUserService userService) : base()
        {
            _userService = userService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// change user activity permission
        /// </summary>
        [HttpPut]
        [Route("user/{userId}/setIsActive/{isActive}")]
        public async Task<Result<CommandResult>> SetIsActive(string userId, bool isActive)
        {
            return await _userService.SetIsActiveAsync(userId, isActive);
        }



        /// <summary>
        /// change user password
        /// </summary>
        [HttpPut]
        [Route("user/{userId}/changePassword")]
        public async Task<Result<CommandResult>> ChangePassword([FromBody] UserChangePasswordDto input)
        {
            return await _userService.ChangePasswordAsync(input.Id, input.OldPassword, input.NewPassword);

        }



        /// <summary>
        /// reset user password
        /// </summary>
        [HttpPut]
        [Route("user/{userId}/resetPassword")]
        public async Task<Result<CommandResult>> ResetPassword([FromBody] UserResetPasswordDto input)
        {
            return await _userService.ResetPasswordAsync(input.Id, input.NewPassword);

        }



        #endregion

        #region  Private Methods


        /// <summary>
        /// 
        /// </summary>
        private AuthenticatedUserModel GetAuthenticatedUserModel(UserBasicInfoDto user)
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