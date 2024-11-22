using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;

namespace TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Specifications;

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
