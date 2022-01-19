using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Cards
{
    public abstract class CardBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; set; }


        [Display(Name = nameof(ApplicationMetadata.BoardId), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string BoardId { get; set; }


        [Display(Name = nameof(ApplicationMetadata.CardType), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.CardType), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public BoardCardType Type { get; set; }
    }

}
