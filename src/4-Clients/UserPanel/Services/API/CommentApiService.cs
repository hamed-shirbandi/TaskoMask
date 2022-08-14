using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class CommentApiService : ICommentApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public CommentApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommentBasicInfoDto>> Get(string id)
        {
            var url = $"/comments/{id}";
            return await _httpClientService.GetAsync<CommentBasicInfoDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(AddCommentDto input)
        {
            var url = $"/comments";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id,UpdateCommentDto input)
        {
            var url = $"/comments/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/comments/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
