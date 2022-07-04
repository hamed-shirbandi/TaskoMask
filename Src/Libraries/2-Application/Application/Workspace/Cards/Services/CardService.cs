using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Cards.Commands.Models;
using TaskoMask.Application.Workspace.Cards.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.ViewModels;
using System.Collections.Generic;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Workspace.Tasks.Queries.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Workspace.Cards.Services
{
    public class CardService : ApplicationService, ICardService
    {
        #region Fields


        #endregion

        #region Ctors

        public CardService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { 

        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(CardUpsertDto input)
        {
            var cmd = new CreateCardCommand(boardId: input.BoardId, name: input.Name, description: input.Description, type: input.Type);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(CardUpsertDto input)
        {
            var cmd = new UpdateCardCommand(id: input.Id, name: input.Name, description: input.Description,type:input.Type);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CardBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetCardByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public Task<Result<IEnumerable<CardDetailsViewModel>>> GetCardDetailsListByBoardIdAsync(string boardId)
        {
            //GetCardDetailsAsync()
            throw new System.NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedListReturnType<CardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchCardsQuery(page, recordsPerPage, term));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetCardsCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteCardCommand(id);
            return await SendCommandAsync(cmd);
        }


        #endregion


        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<Result<CardDetailsViewModel>> GetCardDetailsAsync(string id)
        {
            var cardQueryResult = await SendQueryAsync(new GetCardByIdQuery(id));
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(cardQueryResult.Errors);


            var taskQueryResult = await SendQueryAsync(new GetTasksByCardIdQuery(id));
            if (!taskQueryResult.IsSuccess)
                return Result.Failure<CardDetailsViewModel>(taskQueryResult.Errors);


            var cardDetail = new CardDetailsViewModel
            {
                Card = cardQueryResult.Value,
                Tasks = taskQueryResult.Value,
            };

            return Result.Success(cardDetail);
        }




        #endregion
    }
}
