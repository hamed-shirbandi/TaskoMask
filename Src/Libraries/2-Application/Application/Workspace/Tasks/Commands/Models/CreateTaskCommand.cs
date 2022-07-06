
using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Models
{
    public class CreateTaskCommand : TaskBaseCommand
    {
        public CreateTaskCommand(string title, string cardId, string description)
            : base(title,cardId, description)
        {
        }



    }
}
