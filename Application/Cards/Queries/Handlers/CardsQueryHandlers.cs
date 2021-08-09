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
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Cards.Queries.Handlers
{
    public class CardsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetCardByIdQuery, CardBasicInfoDto>,
        IRequestHandler<GetCardReportQuery, CardReportDto>,
         IRequestHandler<GetCardsByBoardIdQuery, IEnumerable<CardBasicInfoDto>>
    {
        private readonly ICardRepository _cardRepository;
        public CardsQueryHandlers(ICardRepository cardRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardBasicInfoDto> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(request.Id);
            if (card == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Card);

            return _mapper.Map<CardBasicInfoDto>(card);
        }


        public async Task<IEnumerable<CardBasicInfoDto>> Handle(GetCardsByBoardIdQuery request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetListByBoardIdAsync(request.BoardId);
            return _mapper.Map<IEnumerable<CardBasicInfoDto>>(cards);
        }

        public Task<CardReportDto> Handle(GetCardReportQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
