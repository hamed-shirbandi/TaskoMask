﻿using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using System.Collections.Generic;
using TaskoMask.Application.Core.Services.Application;

namespace TaskoMask.Application.Workspace.Cards.Services
{
    public interface ICardService : IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddCardDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateCardDto input);
        Task<Result<IEnumerable<CardDetailsViewModel>>> GetListWithDetailsByBoardIdAsync(string boardId);
        Task<Result<CardBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<PaginatedListReturnType<CardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string boardId);
    }
}
