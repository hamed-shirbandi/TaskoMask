using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication;
using TaskoMask.Presentation.Framework.Share.Services.Cookie;
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
        public async Task<Result<UserJwtTokenDto>> Login(UserLoginDto input)
        {
            var loginResult = await _accountClientService.Login(input);
            return await SignInAsync(loginResult);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Register(MemberRegisterDto input)
        {
            var registerResult = await _accountClientService.Register(input);
            return await SignInAsync(registerResult);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task Logout()
        {
            //Remove jwt token cookie
            _cookieService.Remove(MagicKey.Jwt_Token);

            await _cookieAuthenticationService.SignOutAsync();
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private async Task<Result<UserJwtTokenDto>> SignInAsync(Result<UserJwtTokenDto> result)
        {
            if (!result.IsSuccess)
                return result;

            //Save jwt token by cookie
            _cookieService.Set(MagicKey.Jwt_Token,result.Value.JwtToken);

            //Sign in user by cookie authentication
            var user = JwtParser.ParseClaimsFromJwt(result.Value.JwtToken);
            await _cookieAuthenticationService.SignInAsync(user, isPersistent: false);

            return result;
        }


        #endregion

    }
}