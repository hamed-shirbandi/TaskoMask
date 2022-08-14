using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Services
{
    public interface IBoardService: IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddBoardDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateBoardDto input);
        Task<Result<BoardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<BoardOutputDto>> GetByIdAsync(string id);
        Task<Result<PaginatedListReturnType<BoardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}
