using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Web.Helpers;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.Clients.UserPanel.Services.API
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
        public async Task<Result<CommandResult>> Add(AddOrganizationDto input)
        {
            var url = $"/organizations";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id, UpdateOrganizationDto input)
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
