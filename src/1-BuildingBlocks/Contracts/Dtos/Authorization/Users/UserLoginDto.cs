using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users
{
    public class UserLoginDto
    {

        [Display(Name = nameof(ContractsMetadata.UserName), ResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string UserName { get; set; }


        [Display(Name = nameof(ContractsMetadata.Password), ResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [StringLength(DomainConstValues.User_Password_Max_Length, MinimumLength = DomainConstValues.User_Password_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


       
        /// <summary>
        /// use in cookie authentication
        /// </summary>
        [Display(Name = nameof(ContractsMetadata.RememberMe), ResourceType = typeof(ContractsMetadata))]
        public bool RememberMe { get; set; }

    }
}
