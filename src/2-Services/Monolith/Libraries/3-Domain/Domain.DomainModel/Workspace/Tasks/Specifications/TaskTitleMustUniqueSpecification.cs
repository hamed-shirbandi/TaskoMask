using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Services;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Specifications
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
