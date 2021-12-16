using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class TaskClientService : ITaskClientService
    {
        #region Fields

        private readonly IHttpClientServices _httpClientServices;

        #endregion

        #region Ctor

        public TaskClientService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TaskDetailsViewModel>> Get(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/tasks"))
                .AddParameter("id", id)
                .Uri;

            return await _httpClientServices.GetAsync<TaskDetailsViewModel>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Create(TaskUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/tasks")).Uri;
            return await _httpClientServices.PostAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(TaskUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/tasks")).Uri;
            return await _httpClientServices.PutAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> SetCardId(string taskId, string cardId)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/tasks"))
                .AddParameter("taskId", taskId)
                .AddParameter("cardId", cardId)
                .Uri;
            return await _httpClientServices.PutAsync<CommandResult>(uri);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
