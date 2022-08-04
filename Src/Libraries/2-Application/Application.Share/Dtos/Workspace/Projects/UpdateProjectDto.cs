
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Projects
{
    public class UpdateProjectDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        [StringLength(DomainConstValues.Project_Name_Max_Length, MinimumLength = DomainConstValues.Project_Name_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [MaxLength(DomainConstValues.Project_Description_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; set; }

    }
}
