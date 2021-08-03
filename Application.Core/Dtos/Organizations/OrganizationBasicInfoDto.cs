

using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Organizations
{
    public class OrganizationBasicInfoDto : OrganizationBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
    }


    public  abstract class OrganizationBaseDto
    {
        public string Id { get; set; }

        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Name { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Description { get; set; }


        public string UserId { get; set; }
    }
}
