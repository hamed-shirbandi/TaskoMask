using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Tasks.Write.Domain.Entities;
using TaskoMask.Services.Tasks.Write.Domain.Services;

namespace TaskoMask.Services.Tasks.Write.Domain.Specifications
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
