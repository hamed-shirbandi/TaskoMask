using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Models
{
    public class UpdateOwnerProfileCommand : OwnerBaseCommand
    {
        public UpdateOwnerProfileCommand(string id, string displayName, string email)
              : base(id,displayName, email)
        {

        }

    }
}
