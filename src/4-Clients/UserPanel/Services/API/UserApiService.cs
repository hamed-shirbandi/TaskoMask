using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class UserApiService : IUserApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor


        public UserApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> SetIsActive(string userId, bool isActive)
        {
            var url = $"user/{userId}/setIsActive/{isActive}";
            return await _httpClientService.PutAsync<CommandResult>(url);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> ChangePassword(UserChangePasswordDto input)
        {
            var url = $"user/{input.Id}/changePassword";
            return await _httpClientService.PutAsync<CommandResult>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> ResetPassword(UserResetPasswordDto input)
        {
            var url = $"user/{input.Id}/resetPassword";
            return await _httpClientService.PutAsync<CommandResult>(url);
        }




        #endregion

        #region Private Methods



        #endregion

    }
}
