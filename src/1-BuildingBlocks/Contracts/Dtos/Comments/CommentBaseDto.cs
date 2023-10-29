using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;

public abstract class CommentBaseDto
{
    public string Id { get; set; }

    [MaxLength(
        DomainConstValues.COMMENT_CONTENT_MAX_LENGTH,
        ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error),
        ErrorMessageResourceType = typeof(ContractsMetadata)
    )]
    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Content { get; set; }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string TaskId { get; set; }
}
