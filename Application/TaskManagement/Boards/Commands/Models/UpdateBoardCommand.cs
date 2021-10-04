using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.TaskManagement.Boards.Commands.Models
{
   public class UpdateBoardCommand : BoardBaseCommand
    {
        public UpdateBoardCommand(string id, string name, string description )
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; private set; }

    }
}
