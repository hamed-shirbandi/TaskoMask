using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

public class TaskReportDto
{
    [Display(Name = nameof(ContractsMetadata.ToDoTasksCount), ResourceType = typeof(ContractsMetadata))]
    public long ToDoTasksCount { get; set; }

    [Display(Name = nameof(ContractsMetadata.DoingTasksCount), ResourceType = typeof(ContractsMetadata))]
    public long DoingTasksCount { get; set; }

    [Display(Name = nameof(ContractsMetadata.DoneTasksCount), ResourceType = typeof(ContractsMetadata))]
    public long DoneTasksCount { get; set; }

    [Display(Name = nameof(ContractsMetadata.BacklogTasksCount), ResourceType = typeof(ContractsMetadata))]
    public long BacklogTasksCount { get; set; }
}
