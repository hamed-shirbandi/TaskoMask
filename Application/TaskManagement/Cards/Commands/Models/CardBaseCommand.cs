using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;


namespace TaskoMask.Application.TaskManagement.Cards.Commands.Models
{
  
    public abstract class CardBaseCommand : BaseCommand
    {

        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Name { get; protected set; }


        [StringLength(250, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Description { get; protected set; }
       
        
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public CardType Type { get; protected set; }
        

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string BoardId { get; protected set; }
    }
}
