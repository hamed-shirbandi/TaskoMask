
using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Models
{
    public class AddTaskCommand : TaskBaseCommand
    {
        public AddTaskCommand(string title, string cardId, string description)
            : base(title, description)
        {
            CardId = cardId;

        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string CardId { get; }

    }
}
