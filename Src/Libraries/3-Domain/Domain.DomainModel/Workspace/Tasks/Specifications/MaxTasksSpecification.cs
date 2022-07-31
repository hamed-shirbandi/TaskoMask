using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Services;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.Specifications
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
