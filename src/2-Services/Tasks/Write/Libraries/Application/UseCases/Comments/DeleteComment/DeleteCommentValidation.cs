using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Comments.DeleteComment
{
    public abstract class DeleteCommentValidation<TRequest> : AbstractValidator<TRequest> where TRequest : DeleteCommentRequest
    {
        public DeleteCommentValidation()
        {
        }

    }
}
