using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Comments.AddComment
{
    public abstract class AddCommentValidation<TRequest> : AbstractValidator<TRequest> where TRequest : AddCommentRequest
    {
        public AddCommentValidation()
        {
        }
    }
}
