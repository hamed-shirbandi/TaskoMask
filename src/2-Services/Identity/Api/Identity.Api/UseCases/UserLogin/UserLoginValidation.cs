using FluentValidation;

namespace TaskoMask.Services.Identity.Application.UseCases.UserLogin
{
    public abstract class UserLoginValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UserLoginRequest
    {
        public UserLoginValidation()
        {

        }
    }
}
