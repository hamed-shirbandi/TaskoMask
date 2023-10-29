using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.AddComment;

public abstract class AddCommentValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : AddCommentRequest
{
    public AddCommentValidation() { }
}
