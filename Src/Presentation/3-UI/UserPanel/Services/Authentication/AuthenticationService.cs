using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Share.Models;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication;
using TaskoMask.Presentation.UI.UserPanel.Helpers;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IAccountClientService _accountClientService;
        private readonly ICookieAuthenticationService _cookieAuthenticationService;

        #endregion

        #region Ctor

        public AuthenticationService(IAccountClientService accountClientService, ICookieAuthenticationService cookieAuthenticationService)
        {
            _accountClientService = accountClientService;
            _cookieAuthenticationService = cookieAuthenticationService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<string>> Login(UserLoginDto input)
        {
            var loginResult = await _accountClientService.Login(input);
            if (!loginResult.IsSuccess)
                return loginResult;

            var user = JwtParser.ParseClaimsFromJwt(loginResult.Value);

            await _cookieAuthenticationService.SignInAsync(user, isPersistent: input.RememberMe);
            return loginResult;
        }



        /// <summary>
        /// 
        /// </summary>
        public Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task Logout()
        {
            await _cookieAuthenticationService.SignOutAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}