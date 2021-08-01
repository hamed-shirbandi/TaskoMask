using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Cards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Core.Dtos.Boards;
using System.Collections.Generic;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Entities;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Cards.Services
{
    public class CardService : BaseEntityService<Card>, ICardService
    {


        #region Fields


        #endregion

        #region Ctor

        public CardService(IMediator mediator, IMapper mapper, INotificationHandler<DomainNotification> notifications) : base(mediator, mapper, notifications)
        { }

        #endregion


        #region Command Services

        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(CardInputDto input)
        {
            var project = _mapper.Map<CreateCardCommand>(input);

            return await SendCommandAsync(project);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(CardInputDto input)
        {
            var updateCommand = _mapper.Map<UpdateCardCommand>(input);
            return await SendCommandAsync(updateCommand);
        }


        #endregion

        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<CardOutputDto> GetByIdAsync(string id)
        {
            var query = new GetCardByIdQuery(id);
            return await SendQueryAsync<GetCardByIdQuery, CardOutputDto>(query);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CardInputDto> GetByIdToUpdateAsync(string id)
        {
            var organization = await GetByIdAsync(id);
            return _mapper.Map<CardInputDto>(organization);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CardListViewModel> GetListByBoardIdAsync(string boardId)
        {
            var cardsQuery = new GetCardsByBoardIdQuery(boardId: boardId);
            var cards = await SendQueryAsync<GetCardsByBoardIdQuery, IEnumerable<CardOutputDto>>(cardsQuery);

            var boardQuery = new GetBoardByIdQuery(id: boardId);
            var board = await SendQueryAsync<GetBoardByIdQuery, BoardOutput>(boardQuery);

            return new CardListViewModel
            {
                Board = board,
                Cards = cards,
            };
        }



        #endregion

     
       
    }
}
