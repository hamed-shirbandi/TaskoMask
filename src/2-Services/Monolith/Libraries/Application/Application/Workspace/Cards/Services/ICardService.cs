using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Services
{
    public interface ICardService : IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddCardDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateCardDto input);
        Task<Result<IEnumerable<CardDetailsViewModel>>> GetListWithDetailsByBoardIdAsync(string boardId);
        Task<Result<GetCardDto>> GetByIdAsync(string id);
        Task<Result<PaginatedList<GetCardDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string boardId);
    }
}
