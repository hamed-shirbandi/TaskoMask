using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Roles
{
    public abstract class RoleBaseDto
    {
        public string Id { get; set; }


        [Display(Name = nameof(ContractsMetadata.Name), ResourceType = typeof(ContractsMetadata))]
        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Name { get;  set; }


        [Display(Name = nameof(ContractsMetadata.Description), ResourceType = typeof(ContractsMetadata))]
        [StringLength(250, MinimumLength = 5, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Description { get;  set; }


        [Display(Name = nameof(ContractsMetadata.PermissionsId), ResourceType = typeof(ContractsMetadata))]
        public string[] PermissionsId { get; set; }


    }
}
