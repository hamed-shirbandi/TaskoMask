using FluentValidation;

namespace TaskoMask.Services.Identity.Api.UseCases.UserLogin;

public abstract class UserLoginValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : UserLoginRequest
{
    public UserLoginValidation() { }
}
