using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;


namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class AccountWebService : IAccountWebService
    {
        private readonly IHttpClientServices _httpClientServices;

        public AccountWebService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<string>> Login(UserLoginDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/account/login")).Uri;
            return await _httpClientServices.PostAsync<string>(uri,input);
        }


        /// <summary>
        /// 
        /// </summary>
        public Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            throw new NotImplementedException();
        }


     

    }
}
