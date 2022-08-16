
using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Models
{
    public class AddTaskCommand : TaskBaseCommand
    {
        public AddTaskCommand(string title, string cardId, string description)
            : base(title, description)
        {
            CardId = cardId;

        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string CardId { get; }

    }
}
