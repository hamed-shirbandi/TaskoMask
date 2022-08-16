using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users
{
    public class UserChangePasswordDto
    {
        public string Id { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(ContractsMetadata.User_OldPassword), ResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string OldPassword { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = nameof(ContractsMetadata.User_NewPassword), ResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.User_Password_Max_Length, MinimumLength = DomainConstValues.User_Password_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string NewPassword { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = nameof(ContractsMetadata.User_ConfirmNewPassword), ResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(ContractsMetadata.User_ConfirmPassword_Not_Match), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string ConfirmNewPassword { get; set; }
    }
}
