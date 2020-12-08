using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Cards;
using TaskoMask.Application.Services.Cards.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Cards
{
    public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, CardOutput>
    {
        private readonly ICardRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetCardByIdQueryHandler(ICardRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<CardOutput> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _projectRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CardOutput>(board);
        }
    }
}
