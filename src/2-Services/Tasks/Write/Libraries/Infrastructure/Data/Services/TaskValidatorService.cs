using TaskoMask.Services.Tasks.Write.Domain.Data;
using TaskoMask.Services.Tasks.Write.Domain.Services;

namespace TaskoMask.Services.Tasks.Write.Infrastructure.Data.Services
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
            return !_taskRepository.ExistTask(taskId, boardId, taskTitle);
        }



        /// <summary>
        /// 
        /// </summary>
        public bool CanAddNewTaskToBoard(string boardId, int maxTasksCount)
        {
            var tasksCount = _taskRepository.CountByBoardId(boardId);
            return tasksCount < maxTasksCount;
        }
    }
}
