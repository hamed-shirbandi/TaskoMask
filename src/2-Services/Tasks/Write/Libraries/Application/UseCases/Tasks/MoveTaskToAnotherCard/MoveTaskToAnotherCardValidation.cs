using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.MoveTaskToAnotherCard
{
    public abstract class MoveTaskToAnotherCardValidation<TRequest> : AbstractValidator<TRequest> where TRequest : MoveTaskToAnotherCardRequest
    {
        public MoveTaskToAnotherCardValidation()
        {
        }


        private void ValidateDescription()
        {
        }
    }
}
