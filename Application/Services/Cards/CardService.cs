using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Cards;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Queries.Models.Cards;
using TaskoMask.Application.Services.Cards.Dto;
using TaskoMask.Application.Queries.ViewMoldes;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Cards
{
    public class CardService : BaseApplicationService,ICardService
    {


        #region Fields


        #endregion

        #region Ctor

        public CardService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        #endregion


        #region Command Services

        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(CardInput input)
        {
            var project = _mapper.Map<CreateCardCommand>(input);

            return await _mediator.Send(project);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(CardInput input)
        {
            var updateCommand = _mapper.Map<UpdateCardCommand>(input);
            return await _mediator.Send(updateCommand);
        }


        #endregion

        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<CardOutput> GetByIdAsync(string id)
        {
            var query = new GetCardByIdQuery(id);
            return await _mediator.Send(query);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CardInput> GetByIdToUpdateAsync(string id)
        {
            var organization = await GetByIdAsync(id);
            return _mapper.Map<CardInput>(organization);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CardListViewModel> GetListByBoardIdAsync(string boardId)
        {
            var cardsQuery = new GetCardsByBoardIdQuery(boardId: boardId);
            var cards = await _mediator.Send(cardsQuery);

            var boardQuery = new GetBoardByIdQuery(id: boardId);
            var board = await _mediator.Send(boardQuery);

            return new CardListViewModel
            {
                Board = board,
                Cards = cards,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountAsync()
        {
            var query = new GetCardsCountQuery();
            return await _mediator.Send(query);
        }


        #endregion

     
       
    }
}
