using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Members.Commands.Models
{
    public class UpdateMemberCommand : MemberBaseCommand
    {
        public UpdateMemberCommand(string id, string displayName, string email)
              : base(id,displayName, email)
        {

        }

    }
}
