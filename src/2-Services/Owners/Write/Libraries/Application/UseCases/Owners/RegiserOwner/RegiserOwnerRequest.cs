using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner
{
    public class RegiserOwnerRequest: BaseCommand
    {
        public RegiserOwnerRequest(string displayName, string email, string password)
        {
            DisplayName = displayName;
            Email = email;
            Password = password;
        }


        [StringLength(DomainConstValues.Owner_DisplayName_Max_Length, MinimumLength = DomainConstValues.Owner_DisplayName_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string DisplayName { get; }


        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.Owner_Email_Max_Length, MinimumLength = DomainConstValues.Owner_Email_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [EmailAddress]
        public string Email { get; }


        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.User_Password_Max_Length, MinimumLength = DomainConstValues.User_Password_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Password { get; }

    }
}
