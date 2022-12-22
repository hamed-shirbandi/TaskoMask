using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Services
{
    public interface IBoardService: IApplicationService
    {
        Task<Result<CommandResult>> AddAsync(AddBoardDto input);
        Task<Result<CommandResult>> UpdateAsync(UpdateBoardDto input);
        Task<Result<BoardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<GetBoardDto>> GetByIdAsync(string id);
        Task<Result<long>> CountAsync();
        Task<Result<CommandResult>> DeleteAsync(string id);
    }
}
