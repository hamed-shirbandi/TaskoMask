using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.TaskManagement.Tasks.Commands.Models
{
   public class UpdateTaskCommand : TaskBaseCommand
    {
        public UpdateTaskCommand(string id, string name, string description )
        {
            Id = id;
            Title = name;
            Description = description;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; private set; }


    }
}
