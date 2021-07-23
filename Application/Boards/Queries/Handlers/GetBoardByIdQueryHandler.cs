using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Boards.Queries.Handlers
{
    public class GetBoardByIdQueryHandler : IRequestHandler<GetBoardByIdQuery, BoardOutput>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;
        public GetBoardByIdQueryHandler(IBoardRepository boardRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }

        public async Task<BoardOutput> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(request.Id);
            return _mapper.Map<BoardOutput>(board);
        }
    }
}
