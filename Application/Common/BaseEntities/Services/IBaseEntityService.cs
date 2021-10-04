using System.Threading.Tasks;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Common.BaseEntities.Services
{
    public interface IBaseEntityService:IApplicationService
    {
        Task<Result<long>> CountAsync();

    }
}
