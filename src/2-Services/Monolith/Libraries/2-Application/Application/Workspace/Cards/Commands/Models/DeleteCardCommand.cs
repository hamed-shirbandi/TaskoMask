using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models
{
    public class DeleteCardCommand : BaseCommand
    {
        public DeleteCardCommand(string id)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}
