using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.AddCard;

public sealed class AddCardValidation : AbstractValidator<AddCardRequest>
{
    public AddCardValidation() { }
}
