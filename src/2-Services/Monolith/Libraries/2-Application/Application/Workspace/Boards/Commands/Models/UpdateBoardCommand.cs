using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models
{
    public class UpdateBoardCommand : BoardBaseCommand
    {
        public UpdateBoardCommand(string id, string name, string description)
             : base(name, description)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }

    }
}
