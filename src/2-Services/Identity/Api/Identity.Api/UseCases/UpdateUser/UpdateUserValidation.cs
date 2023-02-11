using FluentValidation;

namespace TaskoMask.Services.Identity.Application.UseCases.UpdateUser
{
    public abstract class UpdateUserValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UpdateUserRequest
    {
        public UpdateUserValidation()
        {
        }

    }
}
