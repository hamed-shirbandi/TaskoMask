using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Owners.Commands.Models
{
    public class DeleteOwnerCommand : BaseCommand
    {
        public DeleteOwnerCommand(string id)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}
