using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class OrganizationApiService : BaseApiService
    {
        #region Fields


        #endregion

        #region Ctor

        public OrganizationApiService(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OrganizationBasicInfoDto>> GetAsync(string id)
        {
            var url = $"/gw/organizations/{id}";
            return await _httpClientService.GetAsync<OrganizationBasicInfoDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<OrganizationDetailsViewModel>>> GetListAsync()
        {
            var url = $"/gw/organizations";
            return await _httpClientService.GetAsync<IEnumerable<OrganizationDetailsViewModel>>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItemsAsync()
        {
            var url = $"/gw/owner/organizations";
            return await _httpClientService.GetAsync<IEnumerable<SelectListItem>>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> AddAsync(AddOrganizationDto input)
        {
            var url = $"/gw/organizations";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(string id, UpdateOrganizationDto input)
        {
            var url = $"/gw/organizations/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var url = $"/gw/organizations/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
