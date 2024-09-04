using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.UpdateCard;

public sealed class UpdateCardValidation : AbstractValidator<UpdateCardRequest>
{
    public UpdateCardValidation() { }
}
