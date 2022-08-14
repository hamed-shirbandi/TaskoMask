using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Models
{
    public class UpdateTaskCommand : TaskBaseCommand
    {
        public UpdateTaskCommand(string id, string title, string description)
            : base(title, description)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}
