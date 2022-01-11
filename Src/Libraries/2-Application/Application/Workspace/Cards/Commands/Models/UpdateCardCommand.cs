using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Cards.Commands.Models
{
   public class UpdateCardCommand : CardBaseCommand
    {
        public UpdateCardCommand(string id, string name, string description, CardType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }


     
    }
}
