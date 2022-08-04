using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Services.API
{
    public class OrganizationApiService : IOrganizationApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public OrganizationApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OrganizationBasicInfoDto>> Get(string id)
        {
            var url = $"/organizations/{id}";
            return await _httpClientService.GetAsync<OrganizationBasicInfoDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<OrganizationDetailsViewModel>>> Get()
        {
            var url = $"/organizations";
            return await _httpClientService.GetAsync<IEnumerable<OrganizationDetailsViewModel>>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems()
        {
            var url = $"/owner/organizations";
            return await _httpClientService.GetAsync<IEnumerable<SelectListItem>>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(OrganizationUpsertDto input)
        {
            var url = $"/organizations";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id,OrganizationUpsertDto input)
        {
            var url = $"/organizations/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/organizations/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
