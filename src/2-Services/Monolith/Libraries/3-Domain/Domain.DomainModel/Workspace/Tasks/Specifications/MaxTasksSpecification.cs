using TaskoMask.Services.Monolith.Domain.Core.Specifications;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Services;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Specifications
{
    internal class MaxTasksSpecification : ISpecification<Task>
    {
        private readonly ITaskValidatorService _taskValidatorService;
        public MaxTasksSpecification(ITaskValidatorService taskValidatorService)
        {
            _taskValidatorService = taskValidatorService;
        }


        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Task task)
        {
            return _taskValidatorService.CanAddNewTaskToBoard(task.BoardId.Value,DomainConstValues.Board_Max_Task_Count);
        }
    }
}
