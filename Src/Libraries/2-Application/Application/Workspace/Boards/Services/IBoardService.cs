using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using System.Collections.Generic;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.Services;

namespace TaskoMask.Application.Workspace.Boards.Services
{
    public interface IBoardService: IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(BoardUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(BoardUpsertDto input);
        Task<Result<BoardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<BoardBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<BoardReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<BoardBasicInfoDto>>> GetListByProjectIdAsync(string projectId);
        Task<Result<PaginatedListReturnType<BoardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);

    }
}
