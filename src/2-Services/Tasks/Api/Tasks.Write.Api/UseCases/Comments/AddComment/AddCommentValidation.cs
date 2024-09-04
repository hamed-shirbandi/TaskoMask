using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.AddComment;

public sealed class AddCommentValidation : AbstractValidator<AddCommentRequest>
{
    public AddCommentValidation() { }
}
