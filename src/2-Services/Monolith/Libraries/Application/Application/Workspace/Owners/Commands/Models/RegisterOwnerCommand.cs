using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Models
{
   public class RegisterOwnerCommand : OwnerBaseCommand
    {
        public RegisterOwnerCommand(string displayName, string email,string password)
      : base(displayName, email)
        {
            Password = password;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.User_Password_Max_Length, MinimumLength = DomainConstValues.User_Password_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Password { get; }
    }
}
