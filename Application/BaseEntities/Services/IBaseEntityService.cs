using System;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.BaseEntities.Services
{
    public interface IBaseEntityService :  IDisposable
    {
        Task<long> CountAsync();

    }
}
