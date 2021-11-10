using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Workspace.Cards.Commands.Models
{
   public class CreateCardCommand : CardBaseCommand
    {
        public CreateCardCommand(string boardId,string name, string description,CardType type)
        {
            Name = name;
            Description = description;
            BoardId = boardId;
            Type = type;
        }

  
    }
}
