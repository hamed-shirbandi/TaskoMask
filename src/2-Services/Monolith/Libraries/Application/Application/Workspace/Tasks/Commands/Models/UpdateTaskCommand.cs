using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Models
{
    public class UpdateTaskCommand : TaskBaseCommand
    {
        public UpdateTaskCommand(string id, string title, string description)
            : base(title, description)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }

    }
}
