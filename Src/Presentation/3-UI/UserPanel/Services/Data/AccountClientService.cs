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

        private readonly IHttpClientServices _httpClientServices;

        #endregion

        #region Ctor


        public AccountClientService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<string>> Login(UserLoginDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/account/login")).Uri;
            return await _httpClientServices.PostAsync<string>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/account/register")).Uri;
            return await _httpClientServices.PostAsync<CommandResult>(uri, input);
        }


        #endregion

        #region Private Methods



        #endregion







    }
}
