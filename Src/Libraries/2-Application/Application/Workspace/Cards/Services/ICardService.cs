using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Commands;
using System.Collections.Generic;
using TaskoMask.Application.Common.Base.Services;

namespace TaskoMask.Application.Workspace.Cards.Services
{
    public interface ICardService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(CardUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(CardUpsertDto input);
        Task<Result<CardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<CardBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<CardReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<CardBasicInfoDto>>> GetListByBoardIdAsync(string boardId);
        Task<Result<PaginatedListReturnType<CardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);

    }
}
