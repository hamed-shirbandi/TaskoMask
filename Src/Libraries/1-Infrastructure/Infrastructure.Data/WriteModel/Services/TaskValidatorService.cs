using TaskoMask.Domain.WriteModel.Workspace.Tasks.Data;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Services;

namespace TaskoMask.Infrastructure.Data.WriteModel.Services
{

    /// <summary>
    /// 
    /// </summary>
    public class TaskValidatorService : ITaskValidatorService
    {
        private readonly ITaskAggregateRepository _taskRepository;

        public TaskValidatorService(ITaskAggregateRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        public bool TaskHasUniqueName(string taskId, string boardId, string taskTitle)
        {
            //TODO check tasks by boardId
            return _taskRepository.ExistTask(taskId,taskTitle);
        }
    }
}
