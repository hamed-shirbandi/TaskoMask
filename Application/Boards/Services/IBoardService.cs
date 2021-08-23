using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Core.Dtos.Boards;
using System.Collections.Generic;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Boards.Services
{
    public interface IBoardService:IBaseApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(BoardInputDto input);
        Task<Result<CommandResult>> UpdateAsync(BoardInputDto input);
        Task<Result<BoardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<BoardBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<BoardReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<BoardBasicInfoDto>>> GetListByProjectIdAsync(string projectId);
    }
}
