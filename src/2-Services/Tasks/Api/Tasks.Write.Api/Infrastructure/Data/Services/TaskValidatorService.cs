using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Data;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;

namespace TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.Services;

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
