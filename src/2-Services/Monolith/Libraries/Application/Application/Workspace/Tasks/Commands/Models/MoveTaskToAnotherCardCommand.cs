using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Models
{
     public class MoveTaskToAnotherCardCommand : BaseCommand
    {
        public MoveTaskToAnotherCardCommand(string taskId,string cardId)
        {
            TaskId = taskId;
            CardId = cardId;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string TaskId { get; }
        public string CardId { get; }

    }
}
