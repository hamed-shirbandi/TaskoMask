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
using TaskoMask.Application.Core.Services.Application;
using TaskoMask.Application.Workspace.Tasks.Services;
using System.Linq;

namespace TaskoMask.Application.Workspace.Cards.Services
{
    public class CardService : ApplicationService, ICardService
    {
        #region Fields

        private readonly ITaskService _taskService;

        #endregion

        #region Ctors

        public CardService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, ITaskService taskService) : base(inMemoryBus, mapper, notifications)
        {
            _taskService = taskService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(CardUpsertDto input)
        {
            var cmd = new CreateCardCommand(boardId: input.BoardId, name: input.Name, type: input.Type);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(CardUpsertDto input)
        {
            var cmd = new UpdateCardCommand(id: input.Id, name: input.Name, type: input.Type);
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
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string boardId)
        {
            var cardQueryResult = await SendQueryAsync(new GetCardsByBoardIdQuery(boardId));
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<IEnumerable<SelectListItem>>(cardQueryResult.Errors);

            var cards = cardQueryResult.Value.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id,

            }).AsEnumerable();

            return Result.Success(cards);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<CardDetailsViewModel>>> GetListWithDetailsByBoardIdAsync(string boardId)
        {
            var cardQueryResult = await SendQueryAsync(new GetCardsByBoardIdQuery(boardId));
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<IEnumerable<CardDetailsViewModel>>(cardQueryResult.Errors);

            var cardsList = new List<CardDetailsViewModel>();

            foreach (var card in cardQueryResult.Value)
            {
                var taskQueryResult = await _taskService.GetListByCardIdAsync(card.Id);
                if (!taskQueryResult.IsSuccess)
                    return Result.Failure<IEnumerable<CardDetailsViewModel>>(taskQueryResult.Errors);


                cardsList.Add(new CardDetailsViewModel
                {
                    Card=card,
                    Tasks= taskQueryResult.Value
                });
            }

            return Result.Success(cardsList.AsEnumerable());
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



        #endregion
    }
}
