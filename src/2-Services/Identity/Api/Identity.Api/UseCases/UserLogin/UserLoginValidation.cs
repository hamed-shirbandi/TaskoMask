using FluentValidation;

namespace TaskoMask.Services.Identity.Api.UseCases.UserLogin;

public sealed class UserLoginValidation : AbstractValidator<UserLoginRequest>
{
    public UserLoginValidation() { }
}
