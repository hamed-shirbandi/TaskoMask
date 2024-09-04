using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.UpdateComment;

public sealed class UpdateCommentValidation : AbstractValidator<UpdateCommentRequest>
{
    public UpdateCommentValidation() { }
}
