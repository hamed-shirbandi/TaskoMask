using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Tasks
{
    public abstract class TaskBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Title), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Title { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; set; }


        [Display(Name = nameof(ApplicationMetadata.CardId), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string CardId { get; set; }

    }
}
