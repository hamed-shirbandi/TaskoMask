using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Team.Members.Services;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Web.Common.Services.Authentication.JwtAuthentication;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Api.Controllers
{
    public class AccountController : BaseApiController, IAccountWebService
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
        public async Task<Result<string>> Login(UserLoginDto input)
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
        public async Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            return await _memberService.CreateAsync(input);
        }




        #endregion

        #region  Private Methods






        #endregion

    }


}