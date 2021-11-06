﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Application.ViewMoldes;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Boards
{
    public interface IBoardService
    {
        Task<Result<CommandResult>> CreateAsync(BoardInput input);
        Task<Result<CommandResult>> UpdateAsync(BoardInput input);
        Task<BoardOutput> GetByIdAsync(string id);
        Task<BoardInput> GetByIdToUpdateAsync(string id);
        Task<BoardListViewModel> GetListByProjectIdAsync(string projectId);
        Task<long> CountAsync();

    }
}
