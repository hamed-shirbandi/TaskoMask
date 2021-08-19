using System;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Helpers;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.BaseEntities.Services
{
    public interface IBaseEntityService : IBaseApplicationService,  IDisposable
    {
        Task<Result<long>> CountAsync();

    }
}
