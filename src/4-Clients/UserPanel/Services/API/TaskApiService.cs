using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class TaskApiService : BaseApiService
    {
        #region Fields


        #endregion

        #region Ctor

        public TaskApiService(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TaskBasicInfoDto>> GetAsync(string id)
        {
            var url = $"/gw/tasks/{id}";
            return await _httpClientService.GetAsync<TaskBasicInfoDto>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TaskDetailsViewModel>> GetDetailsAsync(string id)
        {
            var url = $"/gw/tasks/{id}/details";
            return await _httpClientService.GetAsync<TaskDetailsViewModel>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> AddAsync(AddTaskDto input)
        {
            var url = $"/gw/tasks";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(string id,UpdateTaskDto input)
        {
            var url = $"/gw/tasks/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> MoveTaskToAnotherCardAsync(string taskId, string cardId)
        {
            var url = $"/gw/tasks/{taskId}/moveto/{cardId}";
            return await _httpClientService.PutAsync<CommandResult>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var url = $"/gw/tasks/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
