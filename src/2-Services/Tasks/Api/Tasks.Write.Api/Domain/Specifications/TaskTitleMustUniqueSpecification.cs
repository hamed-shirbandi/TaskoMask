using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Tasks.Write.Api.Domain.Entities;
using TaskoMask.Services.Tasks.Write.Api.Domain.Services;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Specifications
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
