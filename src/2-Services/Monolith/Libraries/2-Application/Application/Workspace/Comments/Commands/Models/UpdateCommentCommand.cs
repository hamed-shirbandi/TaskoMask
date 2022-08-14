using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Enums;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Models
{
    public class UpdateCommentCommand : CommentBaseCommand
    {
        public UpdateCommentCommand(string id, string content)
                : base( content)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }
    }
}
