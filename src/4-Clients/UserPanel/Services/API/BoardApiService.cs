using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class BoardApiService : BaseApiService
    {
        #region Fields


        #endregion

        #region Ctor

        public BoardApiService(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardOutputDto>> Get(string id)
        {
            var url = $"/gw/boards/{id}";
            return await _httpClientService.GetAsync<BoardOutputDto>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardDetailsViewModel>> GetDetails(string id)
        {
            var url = $"/gw/boards/{id}/details";
            return await _httpClientService.GetAsync<BoardDetailsViewModel>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(AddBoardDto input)
        {
            var url = $"/gw/boards";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id, UpdateBoardDto input)
        {
            var url = $"/gw/boards/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/gw/boards/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
