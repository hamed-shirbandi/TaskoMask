using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Data
{
    public class OrganizationClientService : IOrganizationClientService
    {
        #region Fields

        private readonly IHttpClientServices _httpClientServices;

        #endregion

        #region Ctor

        public OrganizationClientService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OrganizationDetailsViewModel>> Get(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/organizations"))
                .AddParameter("id", id)
                .Uri;

            return await _httpClientServices.GetAsync<OrganizationDetailsViewModel>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Create(OrganizationUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/organizations")).Uri;
            return await _httpClientServices.PostAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(OrganizationUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/organizations")).Uri;
            return await _httpClientServices.PutAsync<CommandResult>(uri, input);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
