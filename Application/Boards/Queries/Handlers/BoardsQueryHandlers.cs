using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Boards.Queries.Handlers
{
    public class BoardsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetBoardByIdQuery, BoardOutput>,
        IRequestHandler<GetBoardsByProjectIdQuery, IEnumerable<BoardOutput>>
    {
        private readonly IBoardRepository _boardRepository;
        public BoardsQueryHandlers(IBoardRepository boardRepository, IMapper mapper, IMediator mediator) :base(mediator, mapper)
        {
            _boardRepository = boardRepository;
        }

        public async Task<BoardOutput> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(request.Id);
            return _mapper.Map<BoardOutput>(board);
        }


        public async Task<IEnumerable<BoardOutput>> Handle(GetBoardsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetListByProjectIdAsync(request.ProjectId);
            return _mapper.Map<IEnumerable<BoardOutput>>(boards);
        }


     
    }
}
