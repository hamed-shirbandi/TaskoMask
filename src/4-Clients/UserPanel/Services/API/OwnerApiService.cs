using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Web.Helpers;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class OwnerApiService : IOwnerApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public OwnerApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OwnerBasicInfoDto>> Get()
        {
            var url = $"/owner";
            return await _httpClientService.GetAsync<OwnerBasicInfoDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateProfile(UpdateOwnerProfileDto input)
        {
            var url = $"/owner";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
