using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Helpers;
using TaskoMask.Clients.UserPanel.Helpers;
using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Clients.UserPanel.Services.Authentication
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
        public async Task<Result<UserJwtTokenDto>> Register(RegisterOwnerDto input)
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