using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.ReadModel.Data
{

    public interface ITaskRepository : IBaseAggregateRepository<Entities.Task>
    {
     
    }
}
