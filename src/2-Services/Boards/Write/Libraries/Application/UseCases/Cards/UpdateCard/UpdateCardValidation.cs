using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Cards.UpdateCard
{
    public abstract class UpdateCardValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UpdateCardRequest
    {
        public UpdateCardValidation()
        {
        }
    }
}
