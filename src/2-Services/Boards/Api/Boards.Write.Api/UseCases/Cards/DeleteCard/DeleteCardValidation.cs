using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.DeleteCard;

public sealed class DeleteCardValidation : AbstractValidator<DeleteCardRequest>
{
    public DeleteCardValidation() { }
}
