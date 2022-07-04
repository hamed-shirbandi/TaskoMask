using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Workspace.Boards.Services
{
    public interface IBoardService: IApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(BoardUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(BoardUpsertDto input);
        Task<Result<BoardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<BoardOutputDto>> GetByIdAsync(string id);
        Task<Result<PaginatedListReturnType<BoardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}
