using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Services;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Data;

public interface ITaskAggregateRepository : IBaseAggregateRepository<Entities.Task>
{
    bool ExistTask(string taskId, string boardId, string taskTitle);
    long CountByBoardId(string boardId);
    Task<Entities.Task> GetByCommentIdAsync(string commentId);
}
