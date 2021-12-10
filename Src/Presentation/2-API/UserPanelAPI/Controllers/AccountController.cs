using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Team.Members.Services;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Presentation.Framework.Web.Services.Authentication.JwtAuthentication;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    public class AccountController : BaseApiController, IAccountClientService
    {
        #region Fields

        private readonly IMemberService _memberService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;



        #endregion

        #region Ctor

        public AccountController(IJwtAuthenticationService jwtAuthenticationService, IMemberService memberService, IMapper mapper):base(mapper)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _memberService = memberService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// login member - return jwt token if result is success
        /// </summary>
        [HttpPost]
        [Route("account/login")]
        public async Task<Result<string>> Login([FromBody] UserLoginDto input)
        {

            //get user
            var userQueryResult = await _memberService.GetBaseUserByUserNameAsync(input.Email);
            if (!userQueryResult.IsSuccess)
                return Result.Failure<string>(userQueryResult.Errors, userQueryResult.Message);


            //validate user password
            var validateQueryResult = await _memberService.ValidateUserPasswordAsync(input.Email, input.Password);
            if (!validateQueryResult.IsSuccess || !validateQueryResult.Value)
                return Result.Failure<string>(userQueryResult.Errors, validateQueryResult.Message);

            //model to add its prop to jwt claims
            var user = _mapper.Map<AuthenticatedUser>(userQueryResult.Value);

            //generate and return jwt token
            var token = _jwtAuthenticationService.GenerateJwtToken(user);
            return Result.Success(value: token);

        }




        /// <summary>
        /// register new member
        /// </summary>
        [HttpPost]
        [Route("account/register")]
        public async Task<Result<CommandResult>> Register([FromBody] MemberRegisterDto input)
        {
            return await _memberService.CreateAsync(input);
        }




        #endregion

        #region  Private Methods






        #endregion

    }


}