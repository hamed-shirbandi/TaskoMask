using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.AddCard;

public abstract class AddCardValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : AddCardRequest
{
    public AddCardValidation() { }
}
