using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.MoveTaskToAnotherCard;

public sealed class MoveTaskToAnotherCardValidation : AbstractValidator<MoveTaskToAnotherCardRequest>
{
    public MoveTaskToAnotherCardValidation() { }

    private void ValidateDescription() { }
}
