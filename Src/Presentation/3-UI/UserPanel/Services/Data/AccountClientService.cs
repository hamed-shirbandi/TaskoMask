using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
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
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/account/login")).Uri;
            return await _httpClientService.PostAsync<UserJwtTokenDto>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserJwtTokenDto>> Register(MemberRegisterDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/account/register")).Uri;
            return await _httpClientService.PostAsync<UserJwtTokenDto>(uri, input);
        }


        #endregion

        #region Private Methods



        #endregion







    }
}
