using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.DataModel.Entities;

namespace TaskoMask.Domain.DataModel.Data
{

    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetListByTaskIdAsync(string taskId);
    }
}
