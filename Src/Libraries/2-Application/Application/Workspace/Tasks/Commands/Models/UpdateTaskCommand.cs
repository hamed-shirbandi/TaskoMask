using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Models
{
    public class UpdateTaskCommand : TaskBaseCommand
    {
        public UpdateTaskCommand(string id, string title, string cardId, string description)
            : base(title, cardId, description)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}
