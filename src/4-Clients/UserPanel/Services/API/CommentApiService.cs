using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.BuildingBlocks.Contracts.ApiContracts.Comments;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class CommentApiService : BaseApiService, ICommentWriteApiService, ICommentReadApiService
    {
        #region Fields


        #endregion

        #region Ctor

        public CommentApiService(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommentBasicInfoDto>> Get(string id)
        {
            var url = $"/monolithService/comments/{id}";
            return await _httpClientService.GetAsync<CommentBasicInfoDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(AddCommentDto input)
        {
            var url = $"/monolithService/comments";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id,UpdateCommentDto input)
        {
            var url = $"/monolithService/comments/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/monolithService/comments/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
