using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models
{
    public class AddCardCommand : CardBaseCommand
    {
        public AddCardCommand(string name , string boardId, BoardCardType type)
                : base(name, type)
        {
            BoardId = boardId;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string BoardId { get; }
    }
}
