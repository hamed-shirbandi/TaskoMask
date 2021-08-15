using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Application.Core.Dtos.Boards;
using System.Collections.Generic;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Boards.Services
{
    public interface IBoardService:IBaseEntityService
    {
        Task<Result<CommandResult>> CreateAsync(BoardInputDto input);
        Task<Result<CommandResult>> UpdateAsync(BoardInputDto input);
        Task<Result<BoardDetailViewModel>> GetDetailAsync(string id);
        Task<Result<BoardBasicInfoDto>> GetAsync(string id);
        Task<Result<BoardReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<BoardBasicInfoDto>>> GetListByProjectIdAsync(string projectId);
    }
}
