using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Cards.Commands.Models
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
