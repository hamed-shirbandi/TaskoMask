using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Services.Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountApiController : BaseApiController, IAccountApiService
    {
        #region Fields


        #endregion

        #region Ctor


        /// <summary>
        /// 
        /// </summary>
        public AccountApiController()
        {

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
            return Result.Success(value: new UserJwtTokenDto { JwtToken = "" });
        }




        /// <summary>
        /// register new owner - return jwt token if register is success
        /// </summary>
        [HttpPost]
        [Route("account/register")]
        public async Task<Result<UserJwtTokenDto>> Register([FromBody] RegisterOwnerDto input)
        {
            return Result.Success(value: new UserJwtTokenDto { JwtToken = "" });
        }






        #endregion

        #region  Private Methods




        #endregion

    }


}