using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Identity.Api.UseCases.UpdateUser;

public class UpdateUserRequest : BaseCommand
{
    public UpdateUserRequest(string oldEmail, string newEmail)
    {
        OldEmail = oldEmail;
        NewEmail = newEmail;
    }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string OldEmail { get; }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string NewEmail { get; }
}
