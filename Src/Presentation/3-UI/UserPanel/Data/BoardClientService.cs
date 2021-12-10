using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class BoardClientService : IBoardClientService
    {
        private readonly IHttpClientServices _httpClientServices;

        public BoardClientService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }



        /// <summary>
        /// 
        /// </summary>
        public Task<Result<CommandResult>> Create(BoardUpsertDto input)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        public Task<Result<BoardDetailsViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        public Task<Result<CommandResult>> Update(BoardUpsertDto input)
        {
            throw new NotImplementedException();
        }
    }
}
