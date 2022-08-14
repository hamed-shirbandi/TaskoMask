

using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models
{
    public class AddBoardCommand : BoardBaseCommand
    {
        public AddBoardCommand(string name, string description, string projectId)
           : base(name, description)
        {
            ProjectId = projectId;

        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string ProjectId { get; }

    }
}
