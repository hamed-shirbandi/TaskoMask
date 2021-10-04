
namespace TaskoMask.Application.TaskManagement.Tasks.Commands.Models
{
   public class CreateTaskCommand : TaskBaseCommand
    {
        public CreateTaskCommand(string title, string description, string cardId)
        {
            Title = title;
            Description = description;
            CardId = cardId;
        }

    }
}
