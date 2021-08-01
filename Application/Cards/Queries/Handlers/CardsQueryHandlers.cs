using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Cards.Queries.Handlers
{
    public class CardsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetCardByIdQuery, CardOutputDto>,
         IRequestHandler<GetCardsByBoardIdQuery, IEnumerable<CardOutputDto>>
    {
        private readonly ICardRepository _cardRepository;
        public CardsQueryHandlers(ICardRepository cardRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardOutputDto> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(request.Id);
            if (card == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, typeof(Card));

            return _mapper.Map<CardOutputDto>(card);
        }


        public async Task<IEnumerable<CardOutputDto>> Handle(GetCardsByBoardIdQuery request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetListByBoardIdAsync(request.BoardId);
            return _mapper.Map<IEnumerable<CardOutputDto>>(cards);
        }
    }
}
