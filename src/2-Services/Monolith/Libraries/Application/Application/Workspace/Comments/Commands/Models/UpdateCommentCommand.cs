using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Models
{
    public class UpdateCommentCommand : CommentBaseCommand
    {
        public UpdateCommentCommand(string id, string content)
                : base( content)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }
    }
}
