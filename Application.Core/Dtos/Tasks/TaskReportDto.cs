using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Tasks
{
    public class TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.TasksCount), ResourceType = typeof(ApplicationMetadata))]
        public int TasksCount { get; set; }
       
        [Display(Name = nameof(ApplicationMetadata.ToDoTasksCount), ResourceType = typeof(ApplicationMetadata))]
        public int ToDoTasksCount { get; set; }
        
        [Display(Name = nameof(ApplicationMetadata.DoingTasksCount), ResourceType = typeof(ApplicationMetadata))]
        public int DoingTasksCount { get; set; }
       
        [Display(Name = nameof(ApplicationMetadata.DoneTasksCount), ResourceType = typeof(ApplicationMetadata))]
        public int DoneTasksCount { get; set; }
    }
}
