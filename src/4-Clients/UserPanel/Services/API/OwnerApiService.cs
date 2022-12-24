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
        public async Task<Result<GetOwnerDto>> GetAsync()
        {
            var url = $"/owners-read/owner";
            return await _httpClientService.GetAsync<GetOwnerDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> RegisterAsync(RegisterOwnerDto input)
        {
            var url = $"/owners-write/owner";

            //because this api is anonymous (see AddHttpServices Method in HostingExtensions class)
            _httpClientService.SetHttpClient(MagicKey.Public_ApiGateway_Client);

            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateProfileAsync(UpdateOwnerProfileDto input)
        {
            var url = $"/owners-write/owner";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
