using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class AccountApiService : IAccountApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor


        public AccountApiService(IHttpClientService httpClientService)
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



        #endregion

        #region Private Methods



        #endregion







    }
}
