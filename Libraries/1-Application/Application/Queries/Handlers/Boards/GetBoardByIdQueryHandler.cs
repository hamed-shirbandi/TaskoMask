using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Boards
{
    public class GetBoardByIdQueryHandler : IRequestHandler<GetBoardByIdQuery, BoardOutput>
    {
        private readonly IBoardRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetBoardByIdQueryHandler(IBoardRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<BoardOutput> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _projectRepository.GetByIdAsync(request.Id);
            return _mapper.Map<BoardOutput>(board);
        }
    }
}
