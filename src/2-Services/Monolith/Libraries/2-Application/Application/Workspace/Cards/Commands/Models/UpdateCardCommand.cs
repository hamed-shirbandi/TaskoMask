using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Enums;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models
{
    public class UpdateCardCommand : CardBaseCommand
    {
        public UpdateCardCommand(string id, string name , BoardCardType type)
                : base(name, type)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }
    }
}
