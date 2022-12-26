using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Cards.AddCard
{
    public class AddCardRequest: BaseCommand
    {
        public AddCardRequest(string boardId, string name, BoardCardType type)
        {
            BoardId = boardId;
            Name = name;
            Type = type;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string BoardId { get; }


        [StringLength(DomainConstValues.Organization_Name_Max_Length, MinimumLength = DomainConstValues.Organization_Name_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Name { get; }


        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public BoardCardType Type { get; }

    }
}
