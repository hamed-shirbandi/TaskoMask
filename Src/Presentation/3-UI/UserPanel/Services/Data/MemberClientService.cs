using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Data
{
    public class MemberClientService : IMemberClientService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public MemberClientService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<MemberDetailsViewModel>> Get(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/members/{id}")).Uri;

            return await _httpClientService.GetAsync<MemberDetailsViewModel>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(string email)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/members"))
                .AddParameter("email", email)
                .Uri;
            return await _httpClientService.PutAsync<CommandResult>(uri);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClientService.GetBaseAddress(), $"/members"))
                .AddParameter("id", id)
                .Uri;
            return await _httpClientService.PutAsync<CommandResult>(uri);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
