using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Users.Commands.Models
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(string id, string displayName,string email)
        {
            Id = id;
            DisplayName = displayName;
            Email = email;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; private set; }

    }
}
