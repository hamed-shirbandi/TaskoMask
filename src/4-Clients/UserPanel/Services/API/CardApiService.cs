using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ApiContracts;
using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public class CardApiService : BaseApiService, ICardApiService
    {
        #region Fields


        #endregion

        #region Ctor

        public CardApiService(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CardBasicInfoDto>> Get(string id)
        {
            var url = $"/monolithService/cards/{id}";
            return await _httpClientService.GetAsync<CardBasicInfoDto>(url);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string boardId)
        {
            var url = $"/monolithService/boards/{boardId}/cards";
            return await _httpClientService.GetAsync<IEnumerable<SelectListItem>>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Add(AddCardDto input)
        {
            var url = $"/monolithService/cards";
            return await _httpClientService.PostAsync<CommandResult>(url, input);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Update(string id, UpdateCardDto input)
        {
            var url = $"/monolithService/cards/{id}";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> Delete(string id)
        {
            var url = $"/monolithService/cards/{id}";
            return await _httpClientService.DeleteAsync<CommandResult>(url);
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
