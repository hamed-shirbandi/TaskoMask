using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Boards.Commands.Models
{
    public abstract class BoardCommand : BaseCommand
    {
        public BoardCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ProjectId { get; protected set; }
    }
}
