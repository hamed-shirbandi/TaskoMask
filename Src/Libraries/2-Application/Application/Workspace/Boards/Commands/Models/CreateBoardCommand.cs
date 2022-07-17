

using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Boards.Commands.Models
{
    public class CreateBoardCommand : BoardBaseCommand
    {
        public CreateBoardCommand(string name, string description, string projectId)
           : base(name, description)
        {
            ProjectId = projectId;

        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string ProjectId { get; }

    }
}
