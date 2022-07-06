using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Data
{
    public class TaskClientService : ITaskClientService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public TaskClientService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TaskDetailsViewModel>> Get(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/tasks/{id}")).Uri;

            return await _httpClientService.GetAsync<TaskDetailsViewModel>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Create(TaskUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/tasks")).Uri;
            return await _httpClientService.PostAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id,TaskUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/tasks/{id}")).Uri;
            return await _httpClientService.PutAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> MoveTaskToAnotherCard(string taskId, string cardId)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/tasks/{taskId}/{cardId}")).Uri;
            return await _httpClientService.PutAsync<CommandResult>(uri);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
