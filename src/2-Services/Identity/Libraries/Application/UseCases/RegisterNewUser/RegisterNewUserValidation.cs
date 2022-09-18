using FluentValidation;

namespace TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser
{
    public abstract class RegisterNewUserValidation<TRequest> : AbstractValidator<TRequest> where TRequest : RegisterNewUserRequest
    {
        public RegisterNewUserValidation()
        {
        }

    }
}
