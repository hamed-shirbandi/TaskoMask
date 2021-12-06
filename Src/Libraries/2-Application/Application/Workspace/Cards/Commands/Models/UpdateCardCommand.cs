using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Enums;

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

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; private set; }


     
    }
}
