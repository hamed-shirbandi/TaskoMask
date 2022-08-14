using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Models
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
