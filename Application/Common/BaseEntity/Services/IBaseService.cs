using System.Threading.Tasks;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Base.Services
{
    public interface IBaseService:IApplicationService
    {
        Task<Result<long>> CountAsync();

    }
}
