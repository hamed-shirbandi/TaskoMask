﻿using CSharpFunctionalExtensions;
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
        private readonly IBoardRepository _boardRepository;
        public GetBoardsCountQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<long> Handle(GetBoardsCountQuery request, CancellationToken cancellationToken)
        {
            return await _boardRepository.CountAsync();
        }
    }
}
