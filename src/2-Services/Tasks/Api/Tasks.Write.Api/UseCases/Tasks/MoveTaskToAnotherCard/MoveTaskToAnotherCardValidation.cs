using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.MoveTaskToAnotherCard
{
    public abstract class MoveTaskToAnotherCardValidation<TRequest> : AbstractValidator<TRequest>
        where TRequest : MoveTaskToAnotherCardRequest
    {
        public MoveTaskToAnotherCardValidation() { }

        private void ValidateDescription() { }
    }
}
