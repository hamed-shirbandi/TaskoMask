using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication;
using TaskoMask.Presentation.Framework.Share.Services.Cookie;
using TaskoMask.Presentation.Framework.Share.Services.Http;
using TaskoMask.Presentation.UI.UserPanel.Helpers;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IAccountClientService _accountClientService;
        private readonly ICookieService _cookieService;
        private readonly ICookieAuthenticationService _cookieAuthenticationService;

        #endregion

        #region Ctor

        public AuthenticationService(IAccountClientService accountClientService, ICookieAuthenticationService cookieAuthenticationService, ICookieService cookieService)
        {
            _accountClientService = accountClientService;
            _cookieAuthenticationService = cookieAuthenticationService;
            _cookieService = cookieService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<string>> Login(UserLoginDto input)
        {
            var loginResult = await _accountClientService.Login(input);
            return await SignInAsync(loginResult);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<string>> Register(MemberRegisterDto input)
        {
            var registerResult = await _accountClientService.Register(input);
            return await SignInAsync(registerResult);
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


        /// <summary>
        /// 
        /// </summary>
        private async Task<Result<string>> SignInAsync(Result<string> result)
        {
            if (!result.IsSuccess)
                return result;

            //Save jwt token by cookie
            _cookieService.Set(MagicKey.Jwt_Token,result.Value);

            //Sign in user by cookie authentication
            var user = JwtParser.ParseClaimsFromJwt(result.Value);
            await _cookieAuthenticationService.SignInAsync(user, isPersistent: false);

            return result;
        }


        #endregion

    }
}