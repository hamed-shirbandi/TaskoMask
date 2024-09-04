using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.DeleteComment;

public sealed class DeleteCommentValidation : AbstractValidator<DeleteCommentRequest>
{
    public DeleteCommentValidation() { }
}
