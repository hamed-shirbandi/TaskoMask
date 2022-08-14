using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Enums;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models
{
    public class AddCardCommand : CardBaseCommand
    {
        public AddCardCommand(string name , string boardId, BoardCardType type)
                : base(name, type)
        {
            BoardId = boardId;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string BoardId { get; }
    }
}
