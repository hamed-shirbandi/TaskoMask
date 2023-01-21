using FluentValidation;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.DeleteTask
{
    public abstract class DeleteTaskValidation<TRequest> : AbstractValidator<TRequest> where TRequest : DeleteTaskRequest
    {
        public DeleteTaskValidation()
        {
        }

    }
}
