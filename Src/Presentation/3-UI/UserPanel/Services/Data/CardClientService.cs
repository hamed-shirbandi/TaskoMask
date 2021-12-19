using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Data
{
    public class CardClientService : ICardClientService
    {
        #region Fields

        private readonly IHttpClientServices _httpClientServices;

        #endregion

        #region Ctor

        public CardClientService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CardDetailsViewModel>> Get(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/cards"))
                .AddParameter("id", id)
                .Uri;

            return await _httpClientServices.GetAsync<CardDetailsViewModel>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Create(CardUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/cards")).Uri;
            return await _httpClientServices.PostAsync<CommandResult>(uri, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(CardUpsertDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientServices.GetBaseAddress(), $"/cards")).Uri;
            return await _httpClientServices.PutAsync<CommandResult>(uri, input);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
