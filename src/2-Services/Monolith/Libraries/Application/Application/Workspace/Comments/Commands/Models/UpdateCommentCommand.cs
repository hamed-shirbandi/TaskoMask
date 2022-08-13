using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Comments.Commands.Models
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
