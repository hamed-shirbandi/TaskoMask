using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Owners.Commands.Models
{
   public class RegisterOwnerCommand : OwnerBaseCommand
    {
        public RegisterOwnerCommand(string id, string displayName, string email,string password)
      : base(id, displayName, email)
        {
            Password = password;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.User_Password_Max_Length, MinimumLength = DomainConstValues.User_Password_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Password { get; }
    }
}
