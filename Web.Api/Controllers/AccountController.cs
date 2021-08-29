using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.ViewModels.Users;
using TaskoMask.Application.Managers.Services;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Web.Common.Services.Authentication.JwtAuthentication;

namespace TaskoMask.Web.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        #region Fields

        private readonly IManagerService _managerService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;



        #endregion

        #region Ctor

        public AccountController(IJwtAuthenticationService jwtAuthenticationService, IManagerService managerService, IMapper mapper):base(mapper)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _managerService = managerService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// login managgers - return jwt token if result is success
        /// </summary>
        [HttpPost]
        [Route("account/login")]
        public async Task<Result<string>> Login([FromBody] UserLoginViewModel input)
        {

            //get user
            var userQueryResult = await _managerService.GetBaseUserByUserNameAsync(input.Email);
            if (!userQueryResult.IsSuccess)
                return Result.Failure<string>(userQueryResult.Errors, userQueryResult.Message);


            //validate user password
            var validateQueryResult = await _managerService.ValidateUserPasswordAsync(input.Email, input.Password);
            if (!validateQueryResult.IsSuccess || !validateQueryResult.Value)
                return Result.Failure<string>(userQueryResult.Errors, validateQueryResult.Message);

            //model to add its prop to jwt claims
            var jwtModel = _mapper.Map<UserBaseDto>(userQueryResult.Value);

            //generate and return jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(userQueryResult.Value.UserName, userQueryResult.Value.Id, jwtModel);
            return Result.Success(value: token);

        }




        /// <summary>
        /// register new manager
        /// </summary>
        [HttpPost]
        [Route("account/register")]
        public async Task<Result<CommandResult>> Register(UserInputDto input)
        {
            return await _managerService.CreateAsync(input);
        }




        #endregion


        #region  Private Methods






        #endregion

    }


}