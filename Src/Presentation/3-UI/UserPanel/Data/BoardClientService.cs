using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class BoardClientService : IBoardClientService
    {
        #region Fields

        private readonly IHttpClientServices _httpClientServices;

        #endregion

        #region Ctor

        public BoardClientService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardDetailsViewModel>> Get(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/boards"))
                .AddParameter("id", id)
                .Uri;

            return await _httpClientServices.GetAsync<BoardDetailsViewModel>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Create(BoardUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/boards")).Uri;
            return await _httpClientServices.PostAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(BoardUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/boards")).Uri;
            return await _httpClientServices.PutAsync<CommandResult>(uri, input);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
