using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Specifications;

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
        return _taskValidatorService.CanAddNewTaskToBoard(task.BoardId.Value, DomainConstValues.BOARD_MAX_TASK_COUNT);
    }
}
