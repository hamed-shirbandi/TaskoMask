using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Identity.Application.UseCases.UserLogin
{
    public class UserLoginRequest : BaseQuery<Result>
    {
        public UserLoginRequest(string userName, string password, bool rememberLogin)
        {
            UserName = userName;
            Password = password;
            RememberLogin = rememberLogin;
        }


        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string UserName { get; }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Password { get; }

        public bool RememberLogin { get; }

    }
}
