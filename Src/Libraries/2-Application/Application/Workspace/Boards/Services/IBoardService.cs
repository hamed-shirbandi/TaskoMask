using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using System.Collections.Generic;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Common.Base.Services;

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
        Task<Result<PublicPaginatedListReturnType<BoardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);

    }
}
