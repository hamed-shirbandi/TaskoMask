using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Enums;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Models
{
    public class AddCommentCommand : CommentBaseCommand
    {
        public AddCommentCommand(string taskId , string content)
                : base(content)
        {
            TaskId = taskId;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string TaskId { get; }
    }
}
