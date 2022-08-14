using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.Core.Data;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Data
{
    public interface ITaskAggregateRepository : IBaseAggregateRepository<Entities.Task>
    {
        bool ExistTask(string taskId, string boardId, string taskTitle);
        long CountByBoardId(string boardId);
        Task<Entities.Task> GetByCommentIdAsync(string commentId);
    }
}
