using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IAccountClientService _accountClientService;

        #endregion

        #region Ctor

        public AuthenticationService(IAccountClientService accountClientService)
        {
            _accountClientService = accountClientService;
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
        public async Task<Result<UserJwtTokenDto>> Register(OwnerRegisterDto input)
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
            //_cookieService.Remove(MagicKey.Jwt_Token);

            //await _cookieAuthenticationService.SignOutAsync();
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

            ////Save jwt token by cookie
            //_cookieService.Set(MagicKey.Jwt_Token,result.Value.JwtToken);

            ////Sign in user by cookie authentication
            //var user = JwtParser.ParseClaimsFromJwt(result.Value.JwtToken);
            //await _cookieAuthenticationService.SignInAsync(user, isPersistent: false);

            return result;
        }


        #endregion

    }
}