using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Boards.Services
{
    public interface IBoardService:IBaseEntityService
    {
        #region Command Services

        Task<Result<CommandResult>> CreateAsync(BoardInputDto input);
        Task<Result<CommandResult>> UpdateAsync(BoardInputDto input);

        #endregion

        #region Query Services

        Task<Result<BoardBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<BoardListViewModel>> GetListByProjectIdAsync(string projectId);

        #endregion

    }
}
