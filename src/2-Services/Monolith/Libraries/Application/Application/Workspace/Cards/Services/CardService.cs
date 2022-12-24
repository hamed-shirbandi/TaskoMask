using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Services;
using System.Linq;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Services
{
    public class CardService : ApplicationService, ICardService
    {
        #region Fields

        private readonly ITaskService _taskService;

        #endregion

        #region Ctors

        public CardService(IInMemoryBus inMemoryBus,ITaskService taskService) : base(inMemoryBus)
        {
            _taskService = taskService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> AddAsync(AddCardDto input)
        {
            var cmd = new AddCardCommand(boardId: input.BoardId, name: input.Name, type: input.Type);
            return await _inMemoryBus.SendCommand(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UpdateCardDto input)
        {
            var cmd = new UpdateCardCommand(id: input.Id, name: input.Name, type: input.Type);
            return await _inMemoryBus.SendCommand(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<GetCardDto>> GetByIdAsync(string id)
        {
            return await _inMemoryBus.SendQuery(new GetCardByIdQuery(id));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string boardId)
        {
            var cardQueryResult = await _inMemoryBus.SendQuery(new GetCardsByBoardIdQuery(boardId));
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
            var cardQueryResult = await _inMemoryBus.SendQuery(new GetCardsByBoardIdQuery(boardId));
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
        public async Task<Result<PaginatedList<GetCardDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await _inMemoryBus.SendQuery(new SearchCardsQuery(page, recordsPerPage, term));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await _inMemoryBus.SendQuery(new GetCardsCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteCardCommand(id);
            return await _inMemoryBus.SendCommand(cmd);
        }


        #endregion


        #region Private Methods



        #endregion
    }
}
