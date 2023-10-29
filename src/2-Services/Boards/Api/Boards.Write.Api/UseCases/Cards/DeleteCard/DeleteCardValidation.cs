using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.DeleteCard;

public abstract class DeleteCardValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : DeleteCardRequest
{
    public DeleteCardValidation() { }
}
