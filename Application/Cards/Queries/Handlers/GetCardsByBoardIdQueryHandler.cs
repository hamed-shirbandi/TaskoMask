using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Cards.Queries.Handlers
{
    public class GetCardsByBoardIdQueryHandler : IRequestHandler<GetCardsByBoardIdQuery, IEnumerable<CardOutput>>
    {
        private readonly ICardRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetCardsByBoardIdQueryHandler(ICardRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardOutput>> Handle(GetCardsByBoardIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByBoardIdAsync(request.BoardId);
            return _mapper.Map<IEnumerable<CardOutput>>(projects);
        }
    }
}
