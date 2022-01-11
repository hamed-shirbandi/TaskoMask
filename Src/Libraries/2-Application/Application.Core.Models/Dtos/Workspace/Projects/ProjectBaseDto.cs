using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Projects
{
    public abstract class ProjectBaseDto
    {
        public string Id { get; set; }
       
        
        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Name { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Description { get; set; }


        [Display(Name = nameof(ApplicationMetadata.OrganizationId), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string OrganizationId { get; set; }
    }
}
