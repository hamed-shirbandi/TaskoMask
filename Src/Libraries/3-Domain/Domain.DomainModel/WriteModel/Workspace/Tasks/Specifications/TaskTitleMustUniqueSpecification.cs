using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Services;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Specifications
{
    internal class TaskTitleMustUniqueSpecification : ISpecification<Task>
    {
        private readonly ITaskValidatorService _taskValidatorService;
        public TaskTitleMustUniqueSpecification(ITaskValidatorService taskValidatorService)
        {
            _taskValidatorService = taskValidatorService;
        }



        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Task task)
        {
            return _taskValidatorService.TaskHasUniqueName(task.Id, task.BoardId.Value, task.Title.Value);
        }
    }
}
