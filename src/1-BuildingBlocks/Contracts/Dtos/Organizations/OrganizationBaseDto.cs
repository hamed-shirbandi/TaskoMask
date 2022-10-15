using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations
{
    public abstract class OrganizationBaseDto
    {
        public string Id { get; set; }

        [Display(Name = nameof(ContractsMetadata.Name), ResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.Organization_Name_Max_Length, MinimumLength = DomainConstValues.Organization_Name_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Name { get; set; }


        [Display(Name = nameof(ContractsMetadata.Description), ResourceType = typeof(ContractsMetadata))]
        [MaxLength(DomainConstValues.Organization_Description_Max_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Description { get; set; }

        [JsonIgnore]
        public string OwnerId { get; set; }
    }
}
