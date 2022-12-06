using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.Clients.UserPanel.Helpers;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class OwnerApiService : BaseApiService
    {
        #region Fields


        #endregion

        #region Ctor

        public OwnerApiService(IHttpClientService httpClientService):base(httpClientService)
        {

        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Register(RegisterOwnerDto input)
        {
            var url = $"/gw/owner";

            //because this api is anonymous (see AddHttpServices Method in HostingExtensions class)
            _httpClientService.SetHttpClient(MagicKey.Public_UserPanelApiGateway_Client);

            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OwnerBasicInfoDto>> Get()
        {
            var url = $"/gw/owner";
            return await _httpClientService.GetAsync<OwnerBasicInfoDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateProfile(UpdateOwnerProfileDto input)
        {
            var url = $"/gw/owner";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
