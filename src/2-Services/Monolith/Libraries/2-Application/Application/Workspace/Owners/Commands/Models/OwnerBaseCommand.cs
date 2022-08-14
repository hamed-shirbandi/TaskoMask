using TaskoMask.Services.Monolith.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Models
{
    public abstract class OwnerBaseCommand : BaseCommand
    {
        protected OwnerBaseCommand(string id, string displayName, string email)
        {
            DisplayName = displayName;
            Email = email;
            Id = id;
        }


        /// <summary>
        /// use UserId as shared key between User and Owner
        /// </summary>
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }


        [StringLength(DomainConstValues.Owner_DisplayName_Max_Length, MinimumLength = DomainConstValues.Owner_DisplayName_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string DisplayName { get; }
       
        
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.Owner_Email_Max_Length, MinimumLength = DomainConstValues.Owner_Email_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [EmailAddress]
        public string Email { get; }

    }
}
