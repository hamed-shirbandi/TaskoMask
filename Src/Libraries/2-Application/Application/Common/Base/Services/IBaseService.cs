using System.Threading.Tasks;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Common.Base.Services
{
    public interface IBaseService:IApplicationService
    {
        Task<Result<CommandResult>> DeleteAsync(string id);
        Task<Result<long>> CountAsync();

    }
}
