using System;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.BaseEntities.Services
{
    public interface IBaseEntityService : IBaseApplicationService,  IDisposable
    {
        Task<long> CountAsync();

    }
}
