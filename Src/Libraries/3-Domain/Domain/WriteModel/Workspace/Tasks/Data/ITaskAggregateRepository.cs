using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Data
{
    public interface ITaskAggregateRepository : IBaseRepository<Entities.Task>
    {
        bool ExistTask(string taskId, string boardId, string taskTitle);
        long CountByBoardId(string boardId);
    }
}
