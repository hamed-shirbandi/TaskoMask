using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Boards.Commands.Models
{
    public class DeleteBoardCommand : BaseCommand
    {
        public DeleteBoardCommand(string id)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }

    }
}
