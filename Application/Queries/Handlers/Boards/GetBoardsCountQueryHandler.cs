using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Boards
{
    public class GetBoardsCountQueryHandler : IRequestHandler<GetBoardsCountQuery, long>
    {
        private readonly IBoardRepository _projectRepository;
        public GetBoardsCountQueryHandler(IBoardRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<long> Handle(GetBoardsCountQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.CountAsync();
        }
    }
}
