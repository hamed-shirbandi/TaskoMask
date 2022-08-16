using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Models
{
    public class AddCommentCommand : CommentBaseCommand
    {
        public AddCommentCommand(string taskId , string content)
                : base(content)
        {
            TaskId = taskId;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string TaskId { get; }
    }
}
