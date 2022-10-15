using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Cards
{
    public abstract class CardBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ContractsMetadata.Name), ResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.Card_Name_Max_Length, MinimumLength = DomainConstValues.Card_Name_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Name { get; set; }



        [Display(Name = nameof(ContractsMetadata.BoardId), ResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string BoardId { get; set; }


        [Display(Name = nameof(ContractsMetadata.CardType), ResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.CardType), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public BoardCardType Type { get; set; }
    }

}
