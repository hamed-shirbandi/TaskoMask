using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;

namespace TaskoMask.Services.Monolith.Domain.DataModel.Data
{

    public interface IActivityRepository : IBaseRepository<Entities.Activity>
    {
        Task<IEnumerable<Entities.Activity>> GetListByTaskIdAsync(string taskId);
    }
}
