using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Workspace.Boards.Commands.Models
{
   public class UpdateBoardCommand : BoardBaseCommand
    {
        public UpdateBoardCommand(string id, string name, string description, string projectId)
        {
            Id = id;
            Name = name;
            Description = description;
            ProjectId = projectId;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; }

    }
}
