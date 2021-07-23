using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Boards.Queries.Handlers
{
    public class GetBoardsByProjectIdQueryHandler : IRequestHandler<GetBoardsByProjectIdQuery, IEnumerable<BoardOutput>>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;
        public GetBoardsByProjectIdQueryHandler(IBoardRepository boardRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoardOutput>> Handle(GetBoardsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetListByProjectIdAsync(request.ProjectId);
            return _mapper.Map<IEnumerable<BoardOutput>>(boards);
        }
    }
}
