using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Services.API
{
    public class ProjectClientService : IProjectApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public ProjectClientService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectOutputDto>> Get(string id)
        {
            var url = $"/projects/{id}";
            return await _httpClientService.GetAsync<ProjectOutputDto>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectDetailsViewModel>> GetDetails(string id)
        {
            var url = $"/projects/{id}/details";
            return await _httpClientService.GetAsync<ProjectDetailsViewModel>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string organizationId)
        {
            var url = $"/projects/getSelectListItems/{organizationId}";
            return await _httpClientService.GetAsync<IEnumerable<SelectListItem>>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Create(ProjectCreateDto input)
        {
            var url = $"/projects";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id, ProjectUpdateDto input)
        {
            var url = $"/projects/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/projects/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
