using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Owners.Commands.Models
{
    public class UpdateOwnerProfileCommand : OwnerBaseCommand
    {
        public UpdateOwnerProfileCommand(string id, string displayName, string email)
              : base(id,displayName, email)
        {

        }

    }
}
