using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Web.Helpers;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class TaskApiService : ITaskApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public TaskApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TaskBasicInfoDto>> Get(string id)
        {
            var url = $"/tasks/{id}";
            return await _httpClientService.GetAsync<TaskBasicInfoDto>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TaskDetailsViewModel>> GetDetails(string id)
        {
            var url = $"/tasks/{id}/details";
            return await _httpClientService.GetAsync<TaskDetailsViewModel>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(AddTaskDto input)
        {
            var url = $"/tasks";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id,UpdateTaskDto input)
        {
            var url = $"/tasks/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> MoveTaskToAnotherCard(string taskId, string cardId)
        {
            var url = $"/tasks/{taskId}/moveto/{cardId}";
            return await _httpClientService.PutAsync<CommandResult>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/tasks/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
