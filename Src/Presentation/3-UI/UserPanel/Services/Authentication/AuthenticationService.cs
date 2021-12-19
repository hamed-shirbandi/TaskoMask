using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IHttpClientServices _httpClientServices;

        #endregion

        #region Ctor

        public BoardClientService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardDetailsViewModel>> Get(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/boards"))
                .AddParameter("id", id)
                .Uri;

            return await _httpClientServices.GetAsync<BoardDetailsViewModel>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Create(BoardUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/boards")).Uri;
            return await _httpClientServices.PostAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(BoardUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/boards")).Uri;
            return await _httpClientServices.PutAsync<CommandResult>(uri, input);
        }

        #endregion

        #region Private Methods



        #endregion

        private readonly IAccountClientService _accountClientService;

        public AuthenticationService(IAccountClientService accountClientService)
        {
            _accountClientService = accountClientService;
        }

        public Task<Result<string>> Login(UserLoginDto input)
        {
            throw new NotImplementedException();
        }

      
        public void Logout()
        {
            throw new NotImplementedException();
        }

   

        public Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            throw new NotImplementedException();
        }

    }
}