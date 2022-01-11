using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Models
{
    public class UpdateTaskCommand : TaskBaseCommand
    {
        public UpdateTaskCommand(string id, string title, string description, string cardId)
            : base(title, description, cardId)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}
