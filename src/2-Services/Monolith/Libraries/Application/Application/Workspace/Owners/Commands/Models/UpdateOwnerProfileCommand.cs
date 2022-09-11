using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Models
{
    public class UpdateOwnerProfileCommand : OwnerBaseCommand
    {
        public UpdateOwnerProfileCommand(string id, string displayName, string email)
              : base(displayName, email)
        {
            Id = id;
        }


        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }
    }
}
