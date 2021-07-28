using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Boards.Services
{
    public interface IBoardService:IBaseEntityService
    {
        #region Command Services

        Task<Result<CommandResult>> CreateAsync(BoardInput input);
        Task<Result<CommandResult>> UpdateAsync(BoardInput input);

        #endregion

        #region Query Services

        Task<BoardOutput> GetByIdAsync(string id);
        Task<BoardInput> GetByIdToUpdateAsync(string id);
        Task<BoardListViewModel> GetListByProjectIdAsync(string projectId);

        #endregion

    }
}
