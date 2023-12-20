using FluentValidation;

namespace TaskoMask.Services.Identity.Api.UseCases.RegisterUser;

public abstract class RegisterUserValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : RegisterUserRequest
{
    public RegisterUserValidation() { }
}
