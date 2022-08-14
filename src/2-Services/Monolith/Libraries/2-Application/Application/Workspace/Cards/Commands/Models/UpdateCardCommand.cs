using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models
{
    public class UpdateCardCommand : CardBaseCommand
    {
        public UpdateCardCommand(string id, string name , BoardCardType type)
                : base(name, type)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }
    }
}
