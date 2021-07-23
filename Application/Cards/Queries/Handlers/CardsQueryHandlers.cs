using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Cards.Queries.Handlers
{
    public class CardsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetCardByIdQuery, CardOutput>,
         IRequestHandler<GetCardsByBoardIdQuery, IEnumerable<CardOutput>>
    {
        private readonly ICardRepository _projectRepository;
        public CardsQueryHandlers(ICardRepository projectRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _projectRepository = projectRepository;
        }

        public async Task<CardOutput> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _projectRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CardOutput>(board);
        }


        public async Task<IEnumerable<CardOutput>> Handle(GetCardsByBoardIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByBoardIdAsync(request.BoardId);
            return _mapper.Map<IEnumerable<CardOutput>>(projects);
        }
    }
}
