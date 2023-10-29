using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.UpdateComment;

public abstract class UpdateCommentValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : UpdateCommentRequest
{
    public UpdateCommentValidation() { }
}
