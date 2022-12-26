using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Cards.DeleteCard
{
    public abstract class DeleteCardValidation<TRequest> : AbstractValidator<TRequest> where TRequest : DeleteCardRequest
    {
        public DeleteCardValidation()
        {
        }

    }
}
