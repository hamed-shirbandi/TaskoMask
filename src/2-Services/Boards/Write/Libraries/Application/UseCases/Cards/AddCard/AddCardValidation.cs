using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Cards.AddCard
{
    public abstract class AddCardValidation<TRequest> : AbstractValidator<TRequest> where TRequest : AddCardRequest
    {
        public AddCardValidation()
        {
        }
    }
}
