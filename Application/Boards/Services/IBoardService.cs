using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Boards.Services
{
    public interface IBoardService:IBaseEntityService
    {
        Task<Result<BoardDetailViewModel>> GetDetailAsync(string id);
    }
}
