using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class ProjectApiService : BaseApiService
    {
        #region Fields


        #endregion

        #region Ctor

        public ProjectApiService(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectBasicInfoDto>> GetAsync(string id)
        {
            var url = $"/gw/projects/{id}";
            return await _httpClientService.GetAsync<ProjectBasicInfoDto>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id)
        {
            var url = $"/gw/projects/{id}/details";
            return await _httpClientService.GetAsync<ProjectDetailsViewModel>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItemsAsync(string organizationId)
        {
            var url = $"/gw/projects/getSelectListItems/{organizationId}";
            return await _httpClientService.GetAsync<IEnumerable<SelectListItem>>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> AddAsync(AddProjectDto input)
        {
            var url = $"/gw/projects";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(string id, UpdateProjectDto input)
        {
            var url = $"/gw/projects/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var url = $"/gw/projects/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
