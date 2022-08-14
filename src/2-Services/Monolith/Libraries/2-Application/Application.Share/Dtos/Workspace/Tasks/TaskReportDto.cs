using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks
{
    public class TaskReportDto
    {

        [Display(Name = nameof(ApplicationMetadata.ToDoTasksCount), ResourceType = typeof(ApplicationMetadata))]
        public long ToDoTasksCount { get; set; }

        [Display(Name = nameof(ApplicationMetadata.DoingTasksCount), ResourceType = typeof(ApplicationMetadata))]
        public long DoingTasksCount { get; set; }

        [Display(Name = nameof(ApplicationMetadata.DoneTasksCount), ResourceType = typeof(ApplicationMetadata))]
        public long DoneTasksCount { get; set; }


        [Display(Name = nameof(ApplicationMetadata.BacklogTasksCount), ResourceType = typeof(ApplicationMetadata))]
        public long BacklogTasksCount { get; set; }
    }
}
