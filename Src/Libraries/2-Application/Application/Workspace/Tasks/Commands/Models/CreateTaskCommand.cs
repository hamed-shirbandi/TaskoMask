
namespace TaskoMask.Application.Workspace.Tasks.Commands.Models
{
    public class CreateTaskCommand : TaskBaseCommand
    {
        public CreateTaskCommand(string title, string description, string cardId)
            : base(title, description, cardId)

        {
        }

    }
}
