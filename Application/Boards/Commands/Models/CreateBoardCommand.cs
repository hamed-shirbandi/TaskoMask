


namespace TaskoMask.Application.Boards.Commands.Models
{
   public class CreateBoardCommand : BoardCommand
    {
        public CreateBoardCommand(string name, string description, string projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }

      
    }
}
