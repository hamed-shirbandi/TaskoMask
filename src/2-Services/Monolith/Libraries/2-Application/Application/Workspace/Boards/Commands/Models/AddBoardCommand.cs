

using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models
{
    public class AddBoardCommand : BoardBaseCommand
    {
        public AddBoardCommand(string name, string description, string projectId)
           : base(name, description)
        {
            ProjectId = projectId;

        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string ProjectId { get; }

    }
}
