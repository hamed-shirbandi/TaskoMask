using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Models
{
   public class UpdateTaskCommand : TaskBaseCommand
    {
        public UpdateTaskCommand(string id, string name, string description )
        {
            Id = id;
            Title = name;
            Description = description;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}
