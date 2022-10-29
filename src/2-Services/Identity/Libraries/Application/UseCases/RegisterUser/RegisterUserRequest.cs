using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Identity.Application.UseCases.RegisterUser
{
    public class RegisterUserRequest: BaseCommand
    {

        public RegisterUserRequest(string email, string password)
        {
            Email = email;
            Email = password;
        }



        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Email { get; }



        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Password { get; }

    }
}
