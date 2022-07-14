using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;


namespace TaskoMask.Presentation.UI.UserPanel.Services.Data
{
    public class AccountClientService : IAccountClientService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor


        public AccountClientService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Login(UserLoginDto input)
        {
            var url = $"/account/login";
            return await _httpClientService.PostAsync<UserJwtTokenDto>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Register(OwnerRegisterDto input)
        {
            var url = $"/account/register";
            return await _httpClientService.PostAsync<UserJwtTokenDto>(url, input);
        }


        #endregion

        #region Private Methods



        #endregion







    }
}
