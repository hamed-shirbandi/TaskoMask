using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Boards
{
    public class GetBoardsByProjectIdQueryHandler : IRequestHandler<GetBoardsByProjectIdQuery, IEnumerable<BoardOutput>>
    {
        private readonly IBoardRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetBoardsByProjectIdQueryHandler(IBoardRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoardOutput>> Handle(GetBoardsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByProjectIdAsync(request.ProjectId);
            return _mapper.Map<IEnumerable<BoardOutput>>(projects);
        }
    }
}
