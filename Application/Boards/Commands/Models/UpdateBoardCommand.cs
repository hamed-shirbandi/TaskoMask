
using TaskoMask.Application.Boards.Commands.Validations;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Boards.Commands.Models
{
   public class UpdateBoardCommand : BoardCommand
    {
        public UpdateBoardCommand(string id, string name, string description )
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; private set; }


       
    }
}
