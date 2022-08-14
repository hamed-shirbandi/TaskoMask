using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Models
{
     public class MoveTaskToAnotherCardCommand : BaseCommand
    {
        public MoveTaskToAnotherCardCommand(string taskId,string cardId)
        {
            TaskId = taskId;
            CardId = cardId;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string TaskId { get; }
        public string CardId { get; }

    }
}
