using TaskoMask.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Services;

namespace TaskoMask.Infrastructure.Data.Write.Services
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
