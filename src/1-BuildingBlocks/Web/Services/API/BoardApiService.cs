using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.BuildingBlocks.Web.Services.API
{
    public class BoardApiService : IBoardApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public BoardApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardOutputDto>> Get(string id)
        {
            var url = $"/boards/{id}";
            return await _httpClientService.GetAsync<BoardOutputDto>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardDetailsViewModel>> GetDetails(string id)
        {
            var url = $"/boards/{id}/details";
            return await _httpClientService.GetAsync<BoardDetailsViewModel>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(AddBoardDto input)
        {
            var url = $"/boards";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id, UpdateBoardDto input)
        {
            var url = $"/boards/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/boards/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
