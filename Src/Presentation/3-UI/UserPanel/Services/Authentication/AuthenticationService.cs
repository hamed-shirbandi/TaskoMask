using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.UI.UserPanel.Helpers;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IAccountApiService _accountApiService;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        #endregion

        #region Ctor

        public AuthenticationService(IAccountApiService accountApiService, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _accountApiService = accountApiService;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Login(UserLoginDto input)
        {
            var loginResult = await _accountApiService.Login(input);
            return await SignInAsync(loginResult);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Register(OwnerRegisterDto input)
        {
            var registerResult = await _accountApiService.Register(input);
            return await SignInAsync(registerResult);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(MagicKey.Jwt_Token);
            await _localStorage.RemoveItemAsync(MagicKey.Authenticated_User);

            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
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

            var user = JwtParser.ParseAuthenticatedUserModelFromJwt(result.Value.JwtToken);
            await _localStorage.SetItemAsync(MagicKey.Jwt_Token, result.Value.JwtToken);
            await _localStorage.SetItemAsync(MagicKey.Authenticated_User, user);

            ((AuthStateProvider)_authStateProvider).NotifyUserLoggedIn(result.Value.JwtToken);


            return result;
        }


        #endregion

    }
}