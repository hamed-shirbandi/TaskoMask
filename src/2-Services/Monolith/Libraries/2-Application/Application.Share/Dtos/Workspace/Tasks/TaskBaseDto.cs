using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Tasks
{
    public abstract class TaskBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Title), ResourceType = typeof(ApplicationMetadata))]
        [StringLength(DomainConstValues.Task_Title_Max_Length, MinimumLength = DomainConstValues.Task_Title_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Title { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [MaxLength(DomainConstValues.Task_Description_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; set; }


        [Display(Name = nameof(ApplicationMetadata.CardId), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string CardId { get; set; }

    }
}
